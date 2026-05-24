namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;

/// <summary>
/// Zur Anzeige für aktuellen Spielstatus.
/// </summary>
public sealed class SmV2PeriodTitle
{
    /// <summary>
    /// Spielperiode.
    /// 1 -> 1. Drittel, 2 -> 2. Drittel, 3 -> 3. Drittel, 4 -> Verlängerung, 5 -> Penaltyschießen
    /// 1.5 -> 1. Pause 1, 2.5 -> Pause 2 etc.
    /// </summary>
    [JsonPropertyName( "period" )]
    public decimal? Period { get; set; }

    /// <summary>
    /// Kurze Anzeige.
    /// </summary>
    [JsonPropertyName( "short_title" )]
    public string? ShortTitle { get; set; }

    /// <summary>
    /// Anzeige.
    /// </summary>
    [JsonPropertyName( "title" )]
    public string? Title { get; set; }

    /// <summary>
    /// Ingame-Status
    /// Siehe: <see cref="SmIngameState"/>
    /// </summary>
    [JsonPropertyName( "status_id" )]
    public string? StatusId { get; set; } // IngameState

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "can_end_game" )]
    public bool? CanEndGame { get; set; }

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "optional" )]
    public bool? IsOptional { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName( "running" )]
    public bool? IsRunning { get; set; }
}
