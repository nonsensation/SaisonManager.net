namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/leagues.json

/// <summary>
/// Vorschau auf eine Liga.
/// Wird in der Antwort auf die Anfrage aller Ligen zurückgegeben.
/// </summary>
public class SmV2LeaguePreview
{
    /// <summary>
    /// ID der Liga.
    /// </summary>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; } = -1;

    /// <summary>
    /// Verbands-ID der Liga.
    /// </summary>
    [JsonPropertyName( "operation_id" )]
    public int? OperationId { get; set; } = -1;

    /// <summary>
    /// Name des Verbands der Liga.
    /// </summary>
    [JsonPropertyName( "game_operation" )]
    public string? GameOperation { get; set; } = "";

    /// <summary>
    /// Saison-ID der Liga.
    /// Anmerkung: eigentlich ein Integer.
    /// </summary>
    [JsonPropertyName( "season" )]
    public string? Season { get; set; } = "";

    /// <summary>
    /// Name der Liga.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; } = "";

    /// <summary>
    /// Sortierschlüssel.
    /// </summary>
    [JsonPropertyName( "order_key" )]
    public string? OrderKey { get; set; } = "";

    /// <summary>
    /// Link zur Liga.
    /// </summary>
    [JsonPropertyName( "link" )]
    public string? Link { get; set; } = "";

    /// <summary>
    /// Link zu den Spieltagen der Liga.
    /// </summary>
    [JsonPropertyName( "link_schedule" )]
    public string? LinkSchedule { get; set; } = "";
}
