namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;

// Used in ScheduledGame /leagues/{leagueId}/schedule.json
// Used in Game /games/{gameId}.json


/// <summary>
/// Beschreibung SmV2BaseGame.
/// </summary>
[JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
[JsonDerivedType( typeof( SmV2Game ) , nameof( SmV2Game ) )]
[JsonDerivedType( typeof( SmV2ScheduledGame ) , nameof( SmV2ScheduledGame ) )]
public abstract class SmV2BaseGame
{
    /// <summary>
    /// ArenaId
    /// </summary>
    [JsonPropertyName( "arena" )]
    public int? Arena { get; set; }

    /// <summary>
    /// Name der Turnhalle.
    /// </summary>
    [JsonPropertyName( "arena_name" )]
    public string? ArenaName { get; set; }

    /// <summary>
    /// Adresse der Turnhalle.
    /// </summary>
    [JsonPropertyName( "arena_address" )]
    public string? ArenaAddress { get; set; }

    /// <summary>
    /// Kurzname der Turnhalle.
    /// </summary>
    [JsonPropertyName( "arena_short" )]
    public string? ArenaShort { get; set; }

    /// <summary>
    /// Datum, wann das Spiel stattfindet.  
    /// Format: YYYY-MM-DD  
    /// Beispiel: "2016-01-24"
    /// </summary>
    [JsonPropertyName( "date" )]
    public string? Date { get; set; }

    /// <summary>
    /// Hat das Spiel begonnen?
    /// </summary>
    [JsonPropertyName( "started" )]
    public bool? HasStarted { get; set; }

    /// <summary>
    /// Ist das Spiel beendet?
    /// </summary>
    [JsonPropertyName( "ended" )]
    public bool? HasEnded { get; set; }

    /// <summary>
    /// Name des Heimteams.
    /// </summary>
    [JsonPropertyName( "home_team_name" )]
    public string? HomeTeamName { get; set; }

    /// <summary>
    /// Url zum Logo des Heimteams.
    /// </summary>
    [JsonPropertyName( "home_team_logo" )]
    public string? HomeTeamLogo { get; set; }

    /// <summary>
    /// Url zum kleinen Logo des Heimteams.
    /// Anmerkung: zur Zeit identisch zum normalen Logo.
    /// </summary>
    [JsonPropertyName( "home_team_small_logo" )]
    public string? HomeTeamSmallLogo { get; set; }

    /// <summary>
    /// Name des Gastteams.
    /// </summary>
    [JsonPropertyName( "guest_team_name" )]
    public string? GuestTeamName { get; set; }

    /// <summary>
    /// Url zum Logos des Gastteams.
    /// </summary>
    [JsonPropertyName( "guest_team_logo" )]
    public string? GuestTeamLogo { get; set; }

    /// <summary>
    /// Url zum kleinen Logos des Gastteams.
    /// Anmerkung: zur Zeit identisch zum normalen Logo.
    /// </summary>
    [JsonPropertyName( "guest_team_small_logo" )]
    public string? GuestTeamSmallLogo { get; set; }

    /// <summary>
    /// Schiedsrichter des Spieles.
    /// </summary>
    [JsonPropertyName( "referees" )]
    public ICollection<SmV2Referee?>? Referees { get; set; } = [];

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "notice_type" )]
    public string? NoticeType { get; set; }

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "notice_string" )]
    public string? NoticeString { get; set; }

    // Same as Game.PeriodTitles[ Game.Period ]
    /// <summary>
    /// Aktueller Spiel-Status.
    /// Anmerkung: ist identisch zu Game.PeriodTitle[  Game.Period ]
    /// </summary>
    [JsonPropertyName( "current_period_title" )]
    public SmV2PeriodTitle? CurrentPeriodTitle { get; set; }

    /// <summary>
    /// Ergebnis als lesbarer Text.
    /// </summary>
    [JsonPropertyName( "result_string" )]
    public string? ResultString { get; set; }

    /// <summary>
    /// Spielergebnis.
    /// </summary>
    [JsonPropertyName( "result" )]
    public SmV2Result? Result { get; set; }
}

/// <summary>
/// Spielergebnis.
/// </summary>
public sealed class SmV2Result
{
    /// <summary>
    /// Anzahl der Tore des Heimteams.
    /// </summary>
    [JsonPropertyName( "home_goals" )]
    public int? HomeGoals { get; set; }

    /// <summary>
    /// Anzahl der Tore des Gastteams.
    /// </summary>
    [JsonPropertyName( "guest_goals" )]
    public int? GuestGoals { get; set; }

    /// <summary>
    /// Anzahl der Tore je Spielzeit des Heimteams.
    /// </summary>
    [JsonPropertyName( "home_goals_period" )]
    public ICollection<int?> HomeGoalsPeriod { get; set; } = [];

    /// <summary>
    /// Anzahl der Tore je Spielzeit des Gastteams.
    /// </summary>
    [JsonPropertyName( "guest_goals_period" )]
    public ICollection<int?> GuestGoalsPeriod { get; set; } = [];

    /// <summary>
    /// Ergebniszusatz, z.B. "nach Verlängerung" bzw. "n.V.".
    /// </summary>
    [JsonPropertyName( "postfix" )]
    public SmV2Postfix? Postfix { get; set; }

    /// <summary>
    /// Speilabsage/abbruch.
    /// </summary>
    [JsonPropertyName( "forfait" )]
    public bool? WasForfait { get; set; }

    /// <summary>
    /// Verlängerung.
    /// </summary>
    [JsonPropertyName( "overtime" )]
    public bool? WasOvertime { get; set; }
}

/// <summary>
/// Ergebniszusatz
/// </summary>
public sealed class SmV2Postfix
{
    /// <summary>
    /// Kurzbeschreibung z.B. "n.V.".
    /// </summary>
    [JsonPropertyName( "short" )]
    public string? Short { get; set; }

    /// <summary>
    /// Beschreibung, z.B. "nach Verlängerung".
    /// </summary>
    [JsonPropertyName( "long" )]
    public string? Long { get; set; }
}

/// <summary>
/// Schiedsrichter.
/// </summary>
public sealed class SmV2Referee
{
    /// <summary>
    /// Floorball Deutschland Schiedsrichter Lizens-ID.
    /// </summary>
    [JsonPropertyName( "license_id" )]
    public string? LicenseId { get; set; }

    /// <summary>
    /// Vorname.
    /// </summary>
    [JsonPropertyName( "first_name" )]
    public string? FirstName { get; set; }

    /// <summary>
    /// Nachname.
    /// </summary>
    [JsonPropertyName( "last_name" )]
    public string? LastName { get; set; }
}
