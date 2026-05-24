using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Unihockey.Saisonmanager.Domain;
using Unihockey.Saisonmanager.Domain.SmV2;

namespace Unihockey.Saisonmanager.Api;

#region Core Abstractions (Zero Reflection Engine)

/// <summary>
/// A non-generic marker interface allowing a single type parameter registration method.
/// </summary>
public interface ISmEndpoint
{
    static abstract void Map( IEndpointRouteBuilder app , string baseUrl );
}

/// <summary>
/// Defines a strict, stateless contract for a Saisonmanager endpoint.
/// Uses the Curiously Recurring Template Pattern (TSelf) to resolve static abstract members.
/// </summary>
public interface ISmEndpoint<TSelf, TRequest, TResponse> : ISmEndpoint
    where TSelf : ISmEndpoint<TSelf , TRequest , TResponse> // The CRTP constraint
    where TRequest : notnull // <--- ENFORCES NON-NULLABLE REQUEST BINDING
{
    static abstract string RoutePattern { get; }
    static abstract string GetRoute( TRequest request );

    // Default static implementation satisfies ISmEndpoint.Map completely without reflection
    static void ISmEndpoint.Map( IEndpointRouteBuilder app , string baseUrl )
    {
        app.MapGet( TSelf.RoutePattern , async (
            [AsParameters] TRequest request ,
            HttpClient httpClient ,
            ILoggerFactory loggerFactory ) => {
                var logger = loggerFactory.CreateLogger( TSelf.RoutePattern );
                var resolvedRoute = TSelf.GetRoute( request );
                var targetUrl = $"{baseUrl.TrimEnd( '/' )}/{resolvedRoute.TrimStart( '/' )}";

                try
                {
                    using var response = await httpClient.GetAsync( targetUrl );
                    response.EnsureSuccessStatusCode();

                    // 1. Stream the untouched raw content back to guarantee an exact mirror
                    var rawJson = await response.Content.ReadAsStringAsync();

                    // 2. Enforce strict compile-time validation rules
                    var options = new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true ,
                        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow , // Catches unexpected fields
                        RespectNullableAnnotations = true                           // Catches missing or invalid nulls
                    };

                    // 3. Attempt to parse strictly for validation purposes only
                    try
                    {
                        _ = JsonSerializer.Deserialize<TResponse>( rawJson , options );
                    }
                    catch( JsonException ex )
                    {
                        // Log the schema mismatch (includes the exact JSON Path where it failed)
                        logger.LogWarning(
                            ex ,
                            "Upstream API schema mismatch on {Route}. Path: {Path}. Error: {Message}" ,
                            resolvedRoute , ex.Path , ex.Message );
                    }

                    // 4. Return the exact original JSON text, preserving upstream formatting/ordering
                    return Results.Text( rawJson , contentType: "application/json" , statusCode: (int)response.StatusCode );
                }
                catch( HttpRequestException ex )
                {
                    logger.LogError( ex , "Upstream API call failed for {Route}" , resolvedRoute );
                    return Results.Problem( detail: ex.Message , statusCode: StatusCodes.Status502BadGateway );
                }
            } );
    }
}

public static class SmProxyRegistrationExtensions
{
    /// <summary>
    /// Maps a proxy endpoint using exactly one type parameter. Type parameters are inferred seamlessly.
    /// </summary>
    public static void MapSmEndpoint<TEndpoint>( this IEndpointRouteBuilder app , string baseUrl )
        where TEndpoint : ISmEndpoint
    {
        TEndpoint.Map( app , baseUrl );
    }

    /// <summary>
    /// Master registration helper. If an endpoint payload changes, zero edits are required here.
    /// </summary>
    public static void MapAllSmProxyEndpoints( this IEndpointRouteBuilder app , string baseUrl )
    {
        var grp = app.MapGroup( "/api/v2/" )
            .WithTags( "Saisonmanager API Mirror v2" );

        grp.MapSmEndpoint<SmInitEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmAllGamesEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmAllLeaguesEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmGameEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueScheduleEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmGameOperationLeaguesEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmPenaltyCodesEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmPenaltiesEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueTableEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueGroupedTableEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueScorerEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueAdditionalReferencesEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueGameDayScheduleEndpointConfiguration>( baseUrl );
        grp.MapSmEndpoint<SmLeagueCurrentGameDayScheduleEndpointConfiguration>( baseUrl );
    }
}

#endregion

#region Clean, Stateless Endpoint Definitions

public sealed record SmInitEndpointConfiguration : ISmEndpoint<SmInitEndpointConfiguration , SmEmptyequest , SmV2Init>
{
    public static string RoutePattern => "init.json";
    public static string GetRoute( SmEmptyequest request ) => RoutePattern;
}

public sealed record SmAllGamesEndpointConfiguration : ISmEndpoint<SmAllGamesEndpointConfiguration , SmEmptyequest , List<SmV2GamePreview>>
{
    public static string RoutePattern => "games.json";
    public static string GetRoute( SmEmptyequest request ) => RoutePattern;
}

public sealed record SmAllLeaguesEndpointConfiguration : ISmEndpoint<SmAllLeaguesEndpointConfiguration , SmEmptyequest , List<SmV2LeaguePreview>>
{
    public static string RoutePattern => "leagues.json";
    public static string GetRoute( SmEmptyequest request ) => RoutePattern;
}

public sealed record SmLeagueEndpointConfiguration : ISmEndpoint<SmLeagueEndpointConfiguration , SmLeagueIdRequest , SmV2LeagueWithSimilarLeagues>
{
    public static string RoutePattern => "leagues/{LeagueId:int}.json";
    public static string GetRoute( SmLeagueIdRequest request ) => $"leagues/{request.LeagueId}.json";
}

public sealed record SmGameEndpointConfiguration : ISmEndpoint<SmGameEndpointConfiguration , SmGameIdRequest , SmV2Game>
{
    public static string RoutePattern => "games/{GameId}.json";
    public static string GetRoute( SmGameIdRequest request ) => $"games/{request.GameId}.json";
}

public sealed record SmLeagueScheduleEndpointConfiguration : ISmEndpoint<SmLeagueScheduleEndpointConfiguration , SmLeagueIdRequest , List<SmV2ScheduledGame>>
{
    public static string RoutePattern => "leagues/{LeagueId}/schedule.json";
    public static string GetRoute( SmLeagueIdRequest request ) => $"leagues/{request.LeagueId}/schedule.json";
}

public sealed record SmGameOperationLeaguesEndpointConfiguration : ISmEndpoint<SmGameOperationLeaguesEndpointConfiguration , SmGameOperationIdRequest , List<SmV2League>>
{
    public static string RoutePattern => "game_operations/{GameOperationId}.json";
    public static string GetRoute( SmGameOperationIdRequest request ) => $"game_operations/{request.GameOperationId}/leagues.json";
}

public sealed record SmPenaltyCodesEndpointConfiguration : ISmEndpoint<SmPenaltyCodesEndpointConfiguration , SmEmptyequest , List<SmV2PenaltyCode>>
{
    public static string RoutePattern => "user/leagues/penalty_codes.json";
    public static string GetRoute( SmEmptyequest request ) => RoutePattern;
}

public sealed record SmPenaltiesEndpointConfiguration : ISmEndpoint<SmPenaltiesEndpointConfiguration , SmEmptyequest , List<SmV2Penalty>>
{
    public static string RoutePattern => "user/leagues/penalties.json";
    public static string GetRoute( SmEmptyequest request ) => RoutePattern;
}

public sealed record SmLeagueTableEndpointConfiguration : ISmEndpoint<SmLeagueTableEndpointConfiguration , SmLeagueIdRequest , List<SmV2TableTeam>>
{
    public static string RoutePattern => "leagues/{LeagueId}/table.json";
    public static string GetRoute( SmLeagueIdRequest request ) => $"leagues/{request.LeagueId}/table.json";
}

public sealed record SmLeagueGroupedTableEndpointConfiguration : ISmEndpoint<SmLeagueGroupedTableEndpointConfiguration , SmLeagueIdRequest , Dictionary<string , SmV2TableGroup>>
{
    public static string RoutePattern => "leagues/{LeagueId}/grouped_table.json";
    public static string GetRoute( SmLeagueIdRequest request ) => $"leagues/{request.LeagueId}/grouped_table.json";
}

public sealed record SmLeagueScorerEndpointConfiguration : ISmEndpoint<SmLeagueScorerEndpointConfiguration , SmLeagueIdRequest , List<SmV2ScorerPlayer>>
{
    public static string RoutePattern => "leagues/{LeagueId}/scorer.json";
    public static string GetRoute( SmLeagueIdRequest request ) => $"leagues/{request.LeagueId}/scorer.json";
}

public sealed record SmLeagueAdditionalReferencesEndpointConfiguration : ISmEndpoint<SmLeagueAdditionalReferencesEndpointConfiguration , SmLeagueIdRequest , SmV2AdditionalReferences>
{
    public static string RoutePattern => "admin/leagues/{LeagueId}/additional_references.json";
    public static string GetRoute( SmLeagueIdRequest request ) => $"admin/leagues/{request.LeagueId}/additional_references.json";
}

public sealed record SmLeagueGameDayScheduleEndpointConfiguration : ISmEndpoint<SmLeagueGameDayScheduleEndpointConfiguration , SmLeagueIdGameDayNumberRequest , List<SmV2ScheduledGame>>
{
    public static string RoutePattern => "leagues/{LeagueId}/game_days/{GameDayNumber}/schedule.json";
    public static string GetRoute( SmLeagueIdGameDayNumberRequest request ) => $"leagues/{request.LeagueId}/game_days/{request.GameDayNumber}/schedule.json";
}

public sealed record SmLeagueCurrentGameDayScheduleEndpointConfiguration : ISmEndpoint<SmLeagueCurrentGameDayScheduleEndpointConfiguration , SmLeagueIdRequest , List<SmV2ScheduledGame>>
{
    public static string RoutePattern => "leagues/{LeagueId}/game_days/current/schedule.json";
    public static string GetRoute( SmLeagueIdRequest request ) => $"leagues/{request.LeagueId}/game_days/current/schedule.json";
}

#endregion