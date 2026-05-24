namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/games/35497.json

public class SmV2Game : SmV2BaseGame
{
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    // In Schedule it is an int

    /// <summary>
    /// Anmerkung: in SmV2ScheduledGame ist es ein integer, hier ein struct.
    /// </summary>
    [JsonPropertyName( "game_day" )]
    public SmV2GameDay? GameDay { get; set; }

    // In Schedule it is an int..
    /// <summary>
    /// Anmerkung: in SmV2ScheduledGame ist es ein integer, hier ein string
    /// </summary>
    [JsonPropertyName( "game_number" )]
    public string? GameNumber { get; set; }

    /// <summary>
    /// Startzeit des Spiels.
    /// Im Format "HH:MM"
    /// Beispiel: "19:30"
    /// </summary>
    [JsonPropertyName( "start_time" )]
    public string? StartTime { get; set; }

    /// <summary>
    /// Tatsächliche Startzeit des Spiels.
    /// Im Format "HH:MM"
    /// Beispiel: "19:30"
    /// </summary>
    [JsonPropertyName( "actual_start_time" )]
    public string? ActualStartTime { get; set; }

    /// <summary>
    /// Aktueller Status des Spiels.
    /// Siehe: <see cref="SmGameState"/>
    /// </summary>
    [JsonPropertyName( "game_status" )]
    public string? GameStatus { get; set; }

    /// <summary>
    /// Ingame-Status
    /// Siehe: <see cref="SmIngameState"/>
    /// </summary>
    [JsonPropertyName( "ingame_status" )]
    public string? IngameStatus { get; set; }

    /// <summary>
    /// Anzahl der Zuschauer.
    /// </summary>
    [JsonPropertyName( "audience" )]
    public int? Audience { get; set; }

    /// <summary>
    /// Team-Id des Heimteams.
    /// </summary>
    [JsonPropertyName( "home_team_id" )]
    public int? HomeTeamId { get; set; }

    /// <summary>
    /// Team-Id des Gastteams.
    /// </summary>
    [JsonPropertyName( "guest_team_id" )]
    public int? GuestTeamId { get; set; }

    /// <summary>
    /// Link zum Live-Stream des Spiels.
    /// </summary>
    [JsonPropertyName( "live_stream_link" )]
    public string? LiveStreamLink { get; set; }

    /// <summary>
    /// Link zum Video-on-Demand (VOD) des Spiels.
    /// </summary>
    [JsonPropertyName( "vod_link" )]
    public string? VodLink { get; set; }

    /// <summary>
    /// Liste der Ereignisse, die während des Spiels stattgefunden haben, wie Tore, Strafen, Timeouts usw.
    /// </summary>
    [JsonPropertyName( "events" )]
    public ICollection<SmV2GameEvent?>? Events { get; set; } = [];

    /// <summary>
    /// Liste der Spieler, die an diesem Spiel beteiligt waren, einschließlich ihrer Positionen, Auszeichnungen usw.
    /// </summary>
    [JsonPropertyName( "players" )]
    public SmV2Players? Players { get; set; }

    /// <summary>
    /// Liste der Startspieler für dieses Spiel.
    /// </summary>
    [JsonPropertyName( "starting_players" )]
    public SmV2StartingPlayers? StartingPlayers { get; set; }

    /// <summary>
    /// Auszeichnungen, die vergeben wurden.
    /// </summary>
    [JsonPropertyName( "awards" )]
    public SmV2Awards? Awards { get; set; }

    /// <summary>
    /// Liga-ID, in der das Spiel stattfindet.
    /// </summary>
    [JsonPropertyName( "league_id" )]
    public int? LeagueId { get; set; }

    /// <summary>
    /// Liga-Name, in der das Spiel stattfindet.
    /// </summary>
    [JsonPropertyName( "league_name" )]
    public string? LeagueName { get; set; }

    /// <summary>
    /// Kurzname der Liga, in der das Spiel stattfindet.
    /// </summary>
    [JsonPropertyName( "league_short_name" )]
    public string? LeagueShortName { get; set; }

    /// <summary>
    /// Verbands-ID, in dem das Spiel stattfindet.
    /// </summary>
    [JsonPropertyName( "game_operation_id" )]
    public int? GameOperationId { get; set; }

    /// <summary>
    /// Name des Verbandes, in dem das Spiel stattfindet.
    /// </summary>
    [JsonPropertyName( "game_operation_name" )]
    public string? GameOperationName { get; set; }

    /// <summary>
    /// Kurzname des Verbandes, in dem das Spiel stattfindet.
    /// </summary>
    [JsonPropertyName( "game_operation_short_name" )]
    public string? GameOperationShortName { get; set; }

    /// <summary>
    /// Slug des Verbandes, in dem das Spiel stattfindet. Wird in URLs verwendet.
    /// </summary>
    [JsonPropertyName( "game_operation_slug" )]
    public string? GameOperationSlug { get; set; }

    // Always the same..
    /// <summary>
    /// Bezeichnung des aktuellen Drittels.
    /// Anmerkung: in allen Spielen bisher ist dies immer "1. Drittel", "2. Drittel" oder "3. Drittel".
    /// </summary>
    [JsonPropertyName( "period_titles" )]
    public ICollection<SmV2PeriodTitle?>? PeriodTitles { get; set; } = [];

    // called 'nominated_referee_string' in Schedule
    /// <summary>
    /// Für dieses Spiel nominierte Schiedsrichter.
    /// Anmerkung: in SmV2ScheduledGame ist dieses Feld mit "nominated_referee_string" bezeichnet.
    /// </summary>
    [JsonPropertyName( "nominated_referees" )]
    public string? NominatedReferees { get; set; }

    /// <summary>
    /// Ist dieses Spiel löschbar? (true/false)
    /// Wird wahrscheinlich nur im SaisonManager intern verwendet.
    /// </summary>
    [JsonPropertyName( "deletable" )]
    public bool? IsDeletable { get; set; }
}

/// <summary>
/// Spieler, die an einem Spiel beteiligt sind.
/// </summary>
public class SmV2Players
{
    /// <summary>
    /// Liste von Spielern des Heimteams, die an diesem Spiel beteiligt sind.
    /// </summary>
    [JsonPropertyName( "home" )]
    public ICollection<SmV2TeamPlayer?>? Home { get; set; } = [];

    /// <summary>
    /// Liste von Spielern des Gastteams, die an diesem Spiel beteiligt sind.
    /// </summary>
    [JsonPropertyName( "guest" )]
    public ICollection<SmV2TeamPlayer?>? Guest { get; set; } = [];
}

/// <summary>
/// Startspieler für ein Spiel.
/// </summary>
public class SmV2StartingPlayers
{
    /// <summary>
    /// Liste von Startspielern des Heimteams für dieses Spiel.
    /// </summary>
    [JsonPropertyName( "home" )]
    public ICollection<SmV2StartingPlayer?>? Home { get; set; } = [];

    /// <summary>
    /// Liste von Startspielern des Gastteams für dieses Spiel.
    /// </summary>
    [JsonPropertyName( "guest" )]
    public ICollection<SmV2StartingPlayer?>? Guest { get; set; } = [];
}

/// <summary>
/// Auszeichnungen, die während eines Spiels vergeben wurden.
/// </summary>
public class SmV2Awards
{
    /// <summary>
    /// Liste von Spielern des Heimteams, die während dieses Spiels eine Auszeichnung erhalten haben.
    /// </summary>
    [JsonPropertyName( "home" )]
    public ICollection<SmV2AwardPlayer?>? Home { get; set; } = [];

    /// <summary>
    /// Liste von Spielern des Gastteams, die während dieses Spiels eine Auszeichnung erhalten haben.
    /// </summary>
    [JsonPropertyName( "guest" )]
    public ICollection<SmV2AwardPlayer?>? Guest { get; set; } = [];
}

/// <summary>
/// Ein Spieler, der während eines Spiels eine Auszeichnung erhalten hat.
/// </summary>
public class SmV2AwardPlayer : SmV2BasePlayer
{
    /// <summary>
    /// Die Auszeichnung, die der Spieler erhalten hat. Zum Beispiel "mvp" für Most Valuable Player.  
    /// Bisher nur "mvp" bekannt, aber es könnte in Zukunft weitere Auszeichnungen geben (zB Fair Play).
    /// </summary>
    [JsonPropertyName( "award" )]
    public string? Award { get; set; }

    /// <summary>
    /// Das Team, für das der Spieler spielt.
    /// </summary>
    [JsonPropertyName( "team" )]
    public string? Team { get; set; }
}

/// <summary>
/// Ein Spieler, der am Spiel beteiligt ist.
/// </summary>
public class SmV2TeamPlayer : SmV2BasePlayer
{
    /// <summary>
    /// Kaptän des Teams?
    /// </summary>
    [JsonPropertyName( "captain" )]
    public bool? IsCaptain { get; set; }

    /// <summary>
    /// Goalie?
    /// </summary>
    [JsonPropertyName( "goalkeeper" )]
    public bool? IsGoalkeeper { get; set; }

    /// <summary>
    /// Position des Spielers auf dem Feld.
    /// Anmerkung: bisher nur "Feld" und "Tor" bekannt, aber es könnte in Zukunft weitere Positionen geben.
    /// Die genaue Spielposition (zB Verteidiger, Stürmer) muss über zufällige Aufstellung in Stating-Player ermittelt werden.
    /// </summary>
    [JsonPropertyName( "position" )]
    public string? Position { get; set; } // 'Feld', 'Tor'
}

/// <summary>
/// Starting-4 oder Starting-6.
/// </summary>
public class SmV2StartingPlayer : SmV2BasePlayer
{
    /// <summary>
    /// Position des Startspielers in der Aufstellung.
    /// Anmerkung: bisher nur "defender1/2", "center", "forward1/2" und "goal" bekannt, aber es könnte in Zukunft weitere Positionen geben.
    /// Anmerkung: bei Kleinfeld unbekannt
    /// </summary>
    [JsonPropertyName( "position" )]
    public string? Position { get; set; } // FieldPosition ("defender1"/"goal")

    // neu? Feb 2025

    /// <summary>
    /// Team, für das der Startspieler spielt.
    /// Anmerkung: ggf. neu seit Februar 2025, aber nicht überprüft
    /// </summary>
    [JsonPropertyName( "team" )]
    public string? Team { get; set; }
}

/// <summary>
/// Ein Ereignis, das während eines Spiels stattgefunden hat, wie Tore, Strafen, Timeouts usw.
/// </summary>
public class SmV2GameEvent
{
    /// <summary>
    /// Die ID des Ereignisses.
    /// Beginngt bei 1 und wird für jedes Spiel neu vergeben.
    /// </summary>
    [JsonPropertyName( "event_id" )]
    public int? EventId { get; set; }

    /// <summary>
    /// Die Art des Ereignisses.
    /// Bisher bekannte Werte: "goal", "penalty", "timeout".
    /// </summary>
    [JsonPropertyName( "event_type" )]
    public string? EventType { get; set; }

    /// <summary>
    /// Das Team, das an diesem Ereignis beteiligt ist ("home" oder "guest").
    /// </summary>
    [JsonPropertyName( "event_team" )]
    public string? EventTeam { get; set; }

    /// <summary>
    /// Die Spielperiode, in der das Ereignis stattgefunden hat.
    /// Zum Beispiel: 1, 2, 3 für die regulären Spielperiod
    /// </summary>
    [JsonPropertyName( "period" )]
    public int? Period { get; set; }

    /// <summary>
    /// Anzahl der Tore des Heimteams zum Zeitpunkt des Ereignisses.
    /// </summary>
    [JsonPropertyName( "home_goals" )]
    public int? HomeGoals { get; set; }

    /// <summary>
    /// Anzahl der Tore des Gastteams zum Zeitpunkt des Ereignisses.
    /// </summary>
    [JsonPropertyName( "guest_goals" )]
    public int? GuestGoals { get; set; }

    /// <summary>
    /// Die Uhrzeit, zu der das Ereignis stattgefunden hat, im Format "MM:SS". Zum Beispiel "12:34" für 12 Minuten und 34 Sekunden.
    /// Es gibt allerdings viele Ausnamhen, da anfänglich die Zeit manuell eingetragen wurde, Beispiel: "N.A.", "-.03", "14.$9"
    /// Siehe SaisonManager_Notes.md für weitere Beispiele.
    /// </summary>
    [JsonPropertyName( "time" )]
    public string? Time { get; set; }

    /// <summary>
    /// Sortierungsschlüssel des Ereignisses.
    /// Anmerkung: unbekannt, ob es von der Reihenfolge von "event_id" abweichen kann, aber bisher nicht beobachtet.
    /// </summary>
    [JsonPropertyName( "sortkey" )]
    public string? Sortkey { get; set; }

    /// <summary>
    /// Bei Tor oder Strafen-Event ist es die Trikot-Nummer des Torschützen.
    /// Bei Eigentor ist es die 1000.
    /// Bei Timeout nicht vorhanden.
    /// </summary>
    [JsonPropertyName( "number" )]
    public int? Number { get; set; }

    /// <summary>
    /// Art der Strafe.
    /// Bisher bekannte Werte: "penalty_2", "penalty_5", "penalty_2and2", "penalty_10", "penalty_ms1", "penalty_ms2", "penalty_ms3", "penalty_ms_full", "penalty_ms_tech".
    /// Siehe: <see cref="SmPenaltyType"/>
    /// </summary>
    [JsonPropertyName( "penalty_type" )]
    public string? PenaltyType { get; set; }

    /// <summary>
    /// Art der Strafe als lesbarer String.
    /// </summary>
    [JsonPropertyName( "penalty_type_string" )]
    public string? PenaltyTypeString { get; set; }

    /// <summary>
    /// Grund der Strafe.
    /// Anmerkung: können aus /user/leagues/penalty_codes.json ausgelesen werden.
    /// Siehe: <see cref="SmPenaltyCode"/>
    /// </summary>
    [JsonPropertyName( "penalty_reason" )]
    public int? PenaltyReason { get; set; }

    /// <summary>
    /// Grund der Strafe als lesbarer String.
    /// </summary>
    [JsonPropertyName( "penalty_reason_string" )]
    public string? PenaltyReasonString { get; set; }

    /// <summary>
    /// Trikotnummer des Assist-Geber bei einem Tor.
    /// </summary>
    [JsonPropertyName( "assist" )]
    public int? Assist { get; set; }

    /// <summary>
    /// Art des Tores.
    /// Bisher bekannte Werte: "regular", "penalty_shot", "owngoal", "not_assigned".
    /// Siehe: <see cref="SmGoalType"/>
    /// </summary>
    [JsonPropertyName( "goal_type" )]
    public string? GoalType { get; set; }

    /// <summary>
    /// Art des Tores als lesbarer String.
    /// </summary>
    [JsonPropertyName( "goal_type_string" )]
    public string? GoalTypeString { get; set; }
}
