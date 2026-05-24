namespace Unihockey.Saisonmanager.Domain;


using System.Text.Json;
using System.Text.Json.Serialization;




public static class SmRouteExtensions
{
    public static string ToFastEndpointsRoute( this string pattern ) =>
        pattern.Replace( "{" , "{@" , StringComparison.Ordinal );

    public static string ToMinimalApiRoute( this string pattern ) =>
        pattern.Replace( "}" , ":int}" , StringComparison.Ordinal );
}





public record SmEmptyequest
{
}

public record SmLeagueIdRequest
{
    public int LeagueId { get; set; }
}

public record SmGameIdRequest
{
    public int GameId { get; set; }
}

public record SmGameOperationIdRequest
{
    public int GameOperationId { get; set; }
}

public record SmLeagueIdGameDayNumberRequest
{
    public int LeagueId { get; set; }
    public int GameDayNumber { get; set; }
}
