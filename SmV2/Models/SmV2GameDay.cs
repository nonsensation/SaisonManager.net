namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// used in SmV2Game.GameDay & SmV2Leagues.GameDayTitles

/// <summary>
/// Spieltag für die Anzeige.
/// Anmerkung: wird in SmV2Game.GameDay und SmV2Leagues.GameDayTitles verwendet.
/// </summary>
public class SmV2GameDay
{
    /// <summary>
    /// Spieltags-Nummer.
    /// </summary>
    [JsonPropertyName( "game_day_number" )]
    public int? Number { get; set; }

    /// <summary>
    /// Titel des Spieltags.
    /// </summary>
    [JsonPropertyName( "title" )]
    public string? Title { get; set; }
}
