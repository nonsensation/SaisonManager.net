namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;



// https://saisonmanager.de/api/v2/leagues/1396/schedule.json


/// <summary>
/// 
/// </summary>
// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmLeagueGameDayScheduleResponse ) , nameof( SmLeagueGameDayScheduleResponse ) )]
// [JsonDerivedType( typeof( SmLeagueCurrentGameDayScheduleResponse ) , nameof( SmLeagueCurrentGameDayScheduleResponse ) )]
public class SmV2ScheduledGame : SmV2BaseGame
{
    /// <summary>
    /// Datum und Uhrzeit des Spiels im Format "HH:MM".
    /// Beispiel: "16:00"
    /// </summary>
    [JsonPropertyName( "time" )]
    public string? Time { get; set; }

    /// <summary>
    /// Name des ausrichtenden Vereins.
    /// </summary>
    [JsonPropertyName( "hosting_club" )]
    public string? HostingClub { get; set; }

    /// <summary>
    /// Id des Spiels.
    /// </summary>
    [JsonPropertyName( "game_id" )]
    public int? GameId { get; set; }

    // In Game it is a string..
    /// <summary>
    /// Nummer des Spiels.
    /// Vermutlich Liga-Bezogen.
    /// Anmerkung: in SmV2Game dieses Feld mit der gleichen Bezeichnung ist ein integer.
    /// </summary>
    [JsonPropertyName( "game_number" )]
    public int? GameNumber { get; set; }

    // In Game it is a struct..
    /// <summary>
    /// Nummer des Spieltags.
    /// Anmerkung: in SmV2Game ist dieses Feld ein struct..
    /// </summary>
    [JsonPropertyName( "game_day" )]
    public int? GameDay { get; set; }

    /// <summary>
    /// Spieltags-Id.
    /// Anmerkung: vermutlich ist diese Id auch von SaisonManager einmalig je Spieltag, aber noch nicht überprüft.
    /// </summary>
    [JsonPropertyName( "game_day_id" )]
    public int? GameDayId { get; set; }

    /// <summary>
    /// Bezeichner-ID der Gruppe, zu der das Spiel gehört.
    /// Ist null, wenn das Spiel keiner Gruppe zugeordnet ist.
    /// </summary>
    [JsonPropertyName( "group_identifier" )]
    public string? GroupIdentifier { get; set; } // "group_a" (see: TableGroupIdentifier)

    /// <summary>
    /// Bezeichnung der Serie, zu der das Spiel gehört, z.B. "Halbfinale", "Finale" etc.
    /// Ist null, wenn das Spiel keiner Serie zugeordnet ist.
    /// </summary>
    [JsonPropertyName( "series_title" )]
    public string? SeriesTitle { get; set; } // "Halbfinale"

    /// <summary>
    /// Nummer der Serie, zu der das Spiel gehört.
    /// Ist null, wenn das Spiel keiner Serie zugeordnet ist.
    /// Beispiel: "2  " für das zweite Halbfinale.
    /// </summary>
    [JsonPropertyName( "series_number" )]
    public string? SeriesNumber { get; set; } // "2  "

    /// <summary>
    /// Unbekannt
    /// </summary>
    [JsonPropertyName( "home_team_filling_rule" )]
    public string? HomeTeamFillingRule { get; set; }

    /// <summary>
    /// Unbekannt
    /// </summary>
    [JsonPropertyName( "home_team_filling_title" )]
    public string? HomeTeamFillingTitle { get; set; }

    /// <summary>
    /// Unbekannt
    /// </summary>
    [JsonPropertyName( "home_team_filling_parameter" )]
    public int? HomeTeamFillingParameter { get; set; }

    /// <summary>
    /// Regel, wie die Gastmannschaft für dieses Spiel bestimmt wird.
    /// Ist null, wenn das Spiel keiner Gruppe zugeordnet ist.
    /// Mögliche Werte: "game_loser","place_a","place_b","game_winner" (see: GuestTeamFillingRule)
    /// </summary>
    [JsonPropertyName( "guest_team_filling_rule" )]
    public string? GuestTeamFillingRule { get; set; } // "game_loser","place_a","place_b","game_winner" (see: GuestTeamFillingRule)

    /// <summary>
    /// Bezeichnung, wie die Gastmannschaft für dieses Spiel bestimmt wird.
    /// Ist null, wenn das Spiel keiner Gruppe zugeordnet ist.
    /// Beispiel: "Verlierer Halbfinale 2","Gruppe A / Platz 3".
    /// </summary>
    [JsonPropertyName( "guest_team_filling_title" )]
    public string? GuestTeamFillingTitle { get; set; } // "Verlierer Halbfinale 2","Gruppe A / Platz 3"

    /// <summary>
    /// Parameter, wie die Gastmannschaft für dieses Spiel bestimmt wird.
    /// Ist null, wenn das Spiel keiner Gruppe zugeordnet ist.
    /// Anmerkung: Game-ID wenn "game_loser", Table-ID wenn "place_a".
    /// </summary>
    [JsonPropertyName( "guest_team_filling_parameter" )]
    public int? GuestTeamFillingParameter { get; set; } // gameId when game_loser, tableId when place_a

    // called 'nominated_referees' in Game
    /// <summary>
    /// Nominierte Schiedsrichter als String, z.B. "Max Mustermann, Erika Musterfrau".
    /// Anmerkung: in SmV2Game ist dieses Feld mit "nominated_referees" bezeichnet.
    /// </summary>
    [JsonPropertyName( "nominated_referee_string" )]
    public string? NominatedReferees { get; set; }

    // Seems to be Game.GameStatus ?
    /// <summary>
    /// Status des Spiels, z.B. "scheduled", "postponed", "cancelled".
    /// Anmerkung: in SmV2Game ist dieses Feld mit "game_status" bezeichnet (SmV2Game.GameState).
    /// </summary>
    [JsonPropertyName( "state" )]
    public string? GameState { get; set; }
}
