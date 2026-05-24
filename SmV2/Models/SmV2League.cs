namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;

/// <summary>
/// Eine Liga im Saisonmanager.
/// Ligen werden jede Saison neu erstellt.
/// Ein Mapping zwischen den Saisons könnte durch den Namen erfolgen.
/// </summary>
public class SmV2League
{
    /// <summary>
    /// Id der Liga.
    /// </summary>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Verbands-Id der Liga.
    /// </summary>
    [JsonPropertyName( "game_operation_id" )]
    public int? GameOperationId { get; set; }

    /// <summary>
    /// Name des Verbands.
    /// </summary>
    [JsonPropertyName( "game_operation_name" )]
    public string? GameOperationName { get; set; }

    /// <summary>
    /// Kurzname des Verbands.
    /// </summary>
    [JsonPropertyName( "game_operation_short_name" )]
    public string? GameOperationShortName { get; set; }

    /// <summary>
    /// Slug des Verbands, wird z.B. in URLs verwendet.
    /// </summary>
    [JsonPropertyName( "game_operation_slug" )]
    public string? GameOperationSlug { get; set; }

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "league_category_id" )]
    public string? LeagueCategoryId { get; set; }

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "league_class_id" )]
    public string? LeagueClassId { get; set; }

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "league_system_id" )]
    public string? LeagueSystemId { get; set; }

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "league_type" )]
    public string? LeagueType { get; set; }

    /// <summary>
    /// Name der Liga.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; }


    /// <summary>
    /// Ist es eine Damenliga?
    /// </summary>
    [JsonPropertyName( "female" )]
    public bool? IsFemale { get; set; }

    /// <summary>
    /// Sind Scorer aktiviert?
    /// Anmerkung: bisher immer ja.
    /// </summary>
    [JsonPropertyName( "enable_scorer" )]
    public bool? EnableScorer { get; set; }

    /// <summary>
    /// Kuruzname der Liga.
    /// </summary>
    [JsonPropertyName( "short_name" )]
    public string? ShortName { get; set; }

    /// <summary>
    /// Saison, in der die Liga stattfindet.
    /// </summary>
    [JsonPropertyName( "season_id" )]
    public string? SeasonId { get; set; }

    /// <summary>
    /// Sortierschlüssel der Liga.
    /// </summary>
    [JsonPropertyName( "order_key" )]
    public string? OrderKey { get; set; }

    /// <summary>
    /// Spieltags-Nummern der Liga.
    /// </summary>
    [JsonPropertyName( "game_day_numbers" )]
    public ICollection<int>? GameDayNumbers { get; set; } = [];

    /// <summary>
    /// Spieltags-Titel der Liga.
    /// </summary>
    [JsonPropertyName( "game_day_titles" )]
    public ICollection<SmV2GameDay?>? GameDayTitles { get; set; } = [];

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "deadline" )]
    public object? Deadline { get; set; }

    /// <summary>
    /// Unbekannt.
    /// </summary>
    [JsonPropertyName( "before_deadline" )]
    public object? BeforeDeadline { get; set; }

    /// <summary>
    /// Unbekannt.
    /// Scheint nur in den erstn Saisons 2014 zu sein? (nicht überprüft)
    /// </summary>
    [JsonPropertyName( "legacy_league" )]
    public bool? LegacyLeague { get; set; }

    /// <summary>
    /// Spielfeldgröße der Liga.
    /// Bisher bekannte Werte: "GF", "KF".
    /// Es gibt auch Spielfelder, beispielsweise U13 GF, die kleiner als ein reguläres GF sind - ggf ändert sich hier etwas.
    /// Siehe: <see cref="SmFieldSize"/>
    /// </summary>
    [JsonPropertyName( "field_size" )]
    public string? FieldSize { get; set; }

    /// <summary>
    /// Modus der Liga.
    /// Bisher bekannte Werte: "regular", "cup", "championship".
    /// Siehe: <see cref="SmLeagueMode"/>
    /// </summary>
    [JsonPropertyName( "league_modus" )]
    public string? LeagueModus { get; set; }

    /// <summary>
    /// Unbekannt bzw. noch nicht überprüft
    /// </summary>
    [JsonPropertyName( "has_preround" )]
    public bool? HasPreround { get; set; }

    /// <summary>
    /// Unbekannt bzw. noch nicht überprüft
    /// </summary>
    [JsonPropertyName( "table_modus" )]
    public string? TableModus { get; set; }

    /// <summary>
    /// Anzahl der Spielzeiten pro Spiel.
    /// </summary>
    [JsonPropertyName( "periods" )]
    public int? Periods { get; set; }

    /// <summary>
    /// Länge der Spielzeiten in Minuten.
    /// </summary>
    [JsonPropertyName( "period_length" )]
    public int? PeriodLength { get; set; }

    /// <summary>
    /// Länge der Verlängerung in Minuten.
    /// </summary>
    [JsonPropertyName( "overtime_length" )]
    public int? OvertimeLength { get; set; }
}

public static class LeagueExtensions
{
    public static bool CheckIsJunior( string? name )
    {
        var strComp = StringComparison.OrdinalIgnoreCase;

        if( !string.IsNullOrEmpty( name ) )
        {
            // TODO: check if this is enough
            if( name.Contains( "Junior" , strComp ) ||
                name.Contains( "Nachwuchs" , strComp ) ||
                name.Contains( "U 1" , strComp ) ||
                name.Contains( "U 9" , strComp ) ||
                name.Contains( "U1" , strComp ) ||
                name.Contains( "U9" , strComp ) )
            {
                return true;
            }
        }

        return false;
    }
}
