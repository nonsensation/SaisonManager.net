namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/games.json


/// <summary>
/// 
/// </summary>
// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmAllGamesResponse ) , nameof( SmAllGamesResponse ) )]
public class SmV2GamePreview
{
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Spielnummer.
    /// TODO: können auch string zB bei Gruppenphase etc reinkommen? "winner_a" etc
    /// </summary>
    [JsonPropertyName( "game_number" )]
    public string? GameNumber { get; set; }

    /// <summary>
    /// Startzeit des Spiels.
    /// Im Format ""HH:MM"
    /// Beispiel: "19:30"
    /// </summary>
    [JsonPropertyName( "start_time" )]
    public string? StartTime { get; set; }

    /// <summary>
    /// Anzahl der Zuschauer.
    /// </summary>
    [JsonPropertyName( "audience" )]
    public int? Audience { get; set; }
}
