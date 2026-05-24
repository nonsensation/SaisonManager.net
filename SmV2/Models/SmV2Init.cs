namespace Unihockey.Saisonmanager.Domain.SmV2;

using System.ComponentModel;
using System.Text.Json.Serialization;



// https://saisonmanager.de/api/v2/init.json


// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmInitResponse ) , nameof( SmInitResponse ) )]

/// <summary>
/// Beschreibung der Datenstruktur der aktuellen Saison.
/// </summary>
public class SmV2Init
{
    /// <summary>
    /// Liste aller Saisons im SaisonManager.
    /// </summary>
    [JsonPropertyName( "seasons" )]
    public ICollection<SmV2Season?>? Seasons { get; set; } = [];

    /// <summary>
    /// Die Id der zur Zeit laufenden Saison.
    /// (2024/2025 -> 16)
    /// (2025/2026 -> 17)
    /// </summary>
    [JsonPropertyName( "current_season_id" )]
    public int? CurrentSeasonId { get; set; }

    /// <summary>
    /// Beschreibung als XML Kommentar: Die Spieloperationen.
    /// </summary>
    [JsonPropertyName( "game_operations" )]
    public ICollection<SmV2GameOperation?>? GameOperations { get; set; } = [];
}

/// <summary>
/// Eine Saison.
/// </summary>
public class SmV2Season
{
    /// <summary>
    /// Id der Saison.
    /// Erste Saison 2009/2010 -> Id 1
    /// Aktuelle Saison 2025/2026 -> Id 17
    /// </summary>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Name der Saison, z.B. "2024/2025"
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; }

    /// <summary>
    /// Gibt an, ob es sich um die aktuelle Saison handelt.
    /// Aktuelle Saison 2025/2026 mit Id 17 -> true
    /// </summary>
    [JsonPropertyName( "current" )]
    public bool? IsCurrent { get; set; }
}

/// <summary>
/// Ein Spielbetrieb.
/// 
/// </summary>
public class SmV2GameOperation
{
    /// <summary>
    /// Id des Verbandes in der aktuellen Saison.
    /// Anmerkung: unklar, in wie weit sich Spielbetriebe ändern, ob diese IDs dauerhaft bestehen bleiben.
    /// </summary>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Name des Verbandes.
    /// Beispiel: "Floorball Deutschland"
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; }

    /// <summary>
    /// Kurzname des Verbandes.
    /// Beispiel: "FVD"
    /// </summary>
    [JsonPropertyName( "short_name" )]
    public string? ShortName { get; set; }

    /// <summary>
    /// Slug des Verbandes.
    /// Wird in URLs verwendet.
    /// </summary>
    [JsonPropertyName( "path" )]
    public string? Path { get; set; }

    /// <summary>
    /// Logo-URL des Verbandes.
    /// </summary>
    [JsonPropertyName( "logo_url" )]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Logo-URL des Verbandes im quadratischen Format.
    /// </summary>
    [JsonPropertyName( "logo_quad_url" )]
    public string? LogoQuadUrl { get; set; }

    /// <summary>
    /// Liste der Top-Ligen des Verbandes.
    /// Anmerkung: es sind keine Liga-Ids, sondern die gesamten Ligen als Liste..
    /// </summary>
    [JsonPropertyName( "top_leagues" )]
    public ICollection<SmV2League?>? TopLeagues { get; set; } = [];
}

