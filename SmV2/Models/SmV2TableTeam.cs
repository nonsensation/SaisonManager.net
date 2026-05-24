namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/leagues/1396/table.json

// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmLeagueTableResponse ) , nameof( SmLeagueTableResponse ) )]
public class SmV2TableTeam
{
    /// <summary>
    /// Anzahl gespielter Spiele.
    /// </summary>
    [JsonPropertyName( "games" )]
    public int? Games { get; set; }

    /// <summary>
    /// Anzahl gewonnener Spiele.
    /// </summary>
    [JsonPropertyName( "won" )]
    public int? Won { get; set; }

    /// <summary>
    /// Anzahl unentschiedener Spiele.
    /// </summary>
    [JsonPropertyName( "draw" )]
    public int? Draw { get; set; }

    /// <summary>
    /// Anzahl verlorener Spiele.
    /// </summary>
    [JsonPropertyName( "lost" )]
    public int? Lost { get; set; }

    /// <summary>
    /// Anzahl gewonnener Spiele nach Verlängerung.
    /// </summary>
    [JsonPropertyName( "won_ot" )]
    public int? WonOt { get; set; }

    /// <summary>
    /// Anzahl verlorener Spiele nach Verlängerung.
    /// </summary>
    [JsonPropertyName( "lost_ot" )]
    public int? LostOt { get; set; }

    /// <summary>
    /// Anzahl erzielter Tore.
    /// </summary>
    [JsonPropertyName( "goals_scored" )]
    public int? GoalsScored { get; set; }

    /// <summary>
    /// Anzahl Gegentore.
    /// </summary>
    [JsonPropertyName( "goals_received" )]
    public int? GoalsReceived { get; set; }

    /// <summary>
    /// Tordifferenz (Anzahl erzielter Tore - Anzahl Gegentore).
    /// </summary>
    [JsonPropertyName( "goals_diff" )]
    public int? GoalsDiff { get; set; }

    /// <summary>
    /// Anzahl der Punkte eines Teams.
    /// </summary>
    [JsonPropertyName( "points" )]
    public decimal? Points { get; set; }

    /// <summary>
    /// Name des Teams.
    /// </summary>
    [JsonPropertyName( "team_name" )]
    public string? TeamName { get; set; }

    /// <summary>
    /// Id des Teams.
    /// </summary>
    [JsonPropertyName( "team_id" )]
    public int? TeamId { get; set; }

    /// <summary>
    /// Url zum Logo des Teams.
    /// </summary>
    [JsonPropertyName( "team_logo" )]
    public string? TeamLogo { get; set; }

    /// <summary>
    /// Url zum kleinen Logo des Teams.
    /// (bisher identisch zu team_logo)
    /// </summary>
    [JsonPropertyName( "team_logo_small" )]
    public string? TeamLogoSmall { get; set; }

    /// <summary>
    /// Korrekturen der Punkte eines Teams.
    /// Z.B. bei Entscheidungen des Sportgerichts, die zu einer Änderung der Punkte führen können.
    /// </summary>
    [JsonPropertyName( "point_corrections" )]
    public PointCorrection? PointCorrections { get; set; } // TODO: Check if this is a list

    /// <summary>
    /// Die Sortierreihenfolge der Teams in der Tabelle.
    /// </summary>
    [JsonPropertyName( "sort" )]
    public int? Sort { get; set; }

    /// <summary>
    /// Die Position eines Teams in der Tabelle.
    /// Es werden auch Entscheidungen des Sportgerichts berücksichtigt, die zu einer Änderung der Position führen können.
    /// </summary>
    [JsonPropertyName( "position" )]
    public int? Position { get; set; }
}

/// <summary>
/// Korrektur der Punkte eines Teams, z.B. bei Entscheidungen des Sportgerichts, die zu einer Änderung der Punkte führen können.
/// </summary>
public class PointCorrection
{
    /// <summary>
    /// Anzahl der geänderten Punkte.
    /// </summary>
    [JsonPropertyName( "points" )]
    public decimal? Points { get; set; }

    /// <summary>
    /// Grund der Punkteänderung.
    /// </summary>
    [JsonPropertyName( "reason" )]
    public string? Reason { get; set; }

    /// <summary>
    /// Referenznummer.
    /// </summary>
    [JsonPropertyName( "reference_number" )]
    public string? ReferenceNumber { get; set; }

    /// <summary>
    /// Name des Teams, dessen Punkte geändert wurden.
    /// </summary>
    [JsonPropertyName( "team_name" )]
    public string? TeamName { get; set; }
}

