namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;

// https://saisonmanager.de/api/v2/admin/leagues/1396/additional_references.json

// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmLeagueAdditionalReferencesResponse ) , nameof( SmLeagueAdditionalReferencesResponse ) )]
public class SmV2AdditionalReferences
{
    /// <summary>
    /// Liste von allen Turnhallen, die in der Liga verwendet werden.
    /// </summary>
    [JsonPropertyName( "arenas" )]
    public ICollection<SmV2Arena?>? Arenas { get; set; } = [];

    /// <summary>
    /// Liste von Teams, die in der Liga Spielen.
    /// Ein Team ist nur für die Saison gültig, Teams werden jede Saison neu erstellt.
    /// Ein Mapping von Teams zwischen den Saisons durch den Saisonmanager ist nicht möglich.
    /// </summary>
    [JsonPropertyName( "teams" )]
    public ICollection<SmV2Team?>? Teams { get; set; } = [];

    /// <summary>
    /// Liste von Vereinen, die in der Liga Spielen.
    /// Ein Verein ist über die Saisons hinweg gültig.
    /// </summary>
    [JsonPropertyName( "clubs" )]
    public ICollection<SmV2Club?>? Clubs { get; set; } = [];
}


/// <summary>
/// Eine Turnhalle, die in der Liga verwendet wird.
/// Daten sind teilweise doppelt, fehlerhaft oder unvollständig.
/// </summary>
public class SmV2Arena
{
    /// <summary>
    /// Die ID der Turnhalle.
    /// Beachte: Es existiert eine Turnhalle mit der ArenaId 0, sonst sind sämtliche SaisonManager-IDs > 0.
    /// Daher wird diese spezielle ArenaId ignoriert.
    /// </summary>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Die Kapazität der Turnhalle. In der Regel eine Zahl.
    /// </summary>
    [JsonPropertyName( "capacity" )]
    public string? Capacity { get; set; }

    /// <summary>
    /// Die Stadt, in der sich die Turnhalle befindet.
    /// </summary>
    [JsonPropertyName( "city" )]
    public string? City { get; set; }

    /// <summary>
    /// Ein Kommentar zur Turnhalle, z.B. "Die Halle ist nicht beheizt." oder "Die Halle ist neu renoviert.".
    /// Bisher nicht verwendet.
    /// </summary>
    [JsonPropertyName( "comment" )]
    public string? Comment { get; set; }

    /// <summary>
    /// Erstellungsdatum des Eintrags zur Turnhalle im UTC-Format.
    /// Beispiel: 2015-08-30T13:04:33.000Z
    /// </summary>
    [JsonPropertyName( "created_at" )]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// ID des Benutzers, der den Eintrag zur Turnhalle erstellt hat.
    /// </summary>
    [JsonPropertyName( "created_by" )]
    public int? CreatedBy { get; set; }

    /// <summary>
    /// Wird dieser Eintrag zur Turnhalle verwendet?
    /// </summary>
    [JsonPropertyName( "disabled" )]
    public bool? Disabled { get; set; }

    /// <summary>
    /// Hausnummer der Turnhalle.
    /// </summary>
    [JsonPropertyName( "housenumber" )]
    public string? Housenumber { get; set; }

    /// <summary>
    /// Name der Turnhalle.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; }

    /// <summary>
    /// Postleitzahl der Turnhalle.
    /// </summary>
    [JsonPropertyName( "postcode" )]
    public string? Postcode { get; set; }

    /// <summary>
    /// Ein Hinweis zur Anreise mit öffentlichen Verkehrsmitteln.
    /// </summary>
    [JsonPropertyName( "public_transport_note" )]
    public string? PublicTransportNote { get; set; }

    /// <summary>
    /// Straßenname der Turnhalle.
    /// </summary>
    [JsonPropertyName( "street" )]
    public string? Street { get; set; }

    /// <summary>
    /// Ein Hinweis zur Anreise.
    /// </summary>
    [JsonPropertyName( "travel_note" )]
    public string? TravelNote { get; set; }

    /// <summary>
    /// Das Datum der letzten Aktualisierung des Eintrags zur Turnhalle im UTC-Format.
    /// Beispiel: 2015-08-30T13:04:33.000Z
    /// </summary>
    [JsonPropertyName( "updated_at" )]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// ID des Benutzers, der den Eintrag zur Turnhalle zuletzt aktualisiert hat.
    /// </summary>
    [JsonPropertyName( "updated_by" )]
    public int? UpdatedBy { get; set; }
}

/// <summary>
/// Ein Team, das in der Liga spielt.
/// Das Team ist nur für die Saison gültig, Teams werden jede Saison neu erstellt.
/// Ein Mapping von Teams zwischen den Saisons durch den Saisonmanager ist nicht möglich.
/// </summary>
public class SmV2Team
{
    /// <summary>
    /// Die ID des Teams. (> 0)
    /// </summary>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Vollständiger Name des Teams, z.B. "STV Sedelsberg Hawks".
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; }

    /// <summary>
    /// Kurzname des Teams, z.B. "Hawks".
    /// </summary>
    [JsonPropertyName( "short_name" )]
    public string? ShortName { get; set; }

    /// <summary>
    /// Wird nicht verwendet (null).
    /// </summary>
    [JsonPropertyName( "logo" )]
    public object? Logo { get; set; }

    /// <summary>
    /// Liga-ID in der das Team spielt.
    /// </summary>
    [JsonPropertyName( "league_id" )]
    public int? LeagueId { get; set; }

    /// <summary>
    /// Weitere Liga-IDs, in denen das Team spielt., z.B. in einem Pokalwettbewerb.
    /// </summary>
    [JsonPropertyName( "cup_leagues" )]
    public ICollection<int?>? CupLeagues { get; set; } = [];

    /// <summary>
    /// ID des Vereins, dem das Team zugeordnet ist.
    /// </summary>
    [JsonPropertyName( "club_id" )]
    public int? ClubId { get; set; }

    /// <summary>
    /// Name der Liga, in der das Team spielt.
    /// </summary>
    [JsonPropertyName( "league_name" )]
    public string? LeagueName { get; set; }

    /// <summary>
    /// Kurzname der Liga, in der das Team spielt.
    /// </summary>
    [JsonPropertyName( "league_short_name" )]
    public string? LeagueShortName { get; set; }

    /// <summary>
    /// ID des Verbandes, in dem das Team spielt.
    /// </summary>
    [JsonPropertyName( "game_operation_id" )]
    public int? GameOperationId { get; set; }

    /// <summary>
    /// Name des Verbandes, in dem das Team spielt.
    /// Beispiel: "Floorball Niedersachsen"
    /// </summary>
    [JsonPropertyName( "game_operation_name" )]
    public string? GameOperationName { get; set; }

    /// <summary>
    /// Kurzname des Verbandes, in dem das Team spielt.
    /// Beispiel: "FVNB"
    /// </summary>
    [JsonPropertyName( "game_operation_short_name" )]
    public string? GameOperationShortName { get; set; }

    /// <summary>
    /// Slug des Verbandes, in dem das Team spielt. Wird in URLs verwendet.
    /// Beispiel: "fvnb"
    /// </summary>
    [JsonPropertyName( "game_operation_slug" )]
    public string? GameOperationSlug { get; set; }

    /// <summary>
    /// Ist das Team ein Zusammenschluss aus mehreren Vereinen?
    /// </summary>
    [JsonPropertyName( "syndicate" )]
    public bool? IsSyndicate { get; set; }

    /// <summary>
    /// Liste von Vereins-IDs, die an einem Zusammenschluss beteiligt sind.
    /// </summary>
    [JsonPropertyName( "syndicate_clubs" )]
    public ICollection<int?>? SyndicateClubs { get; set; } = [];

    /// <summary>
    /// Url zum Logo des Teams.
    /// </summary>
    [JsonPropertyName( "logo_url" )]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Url zum kleinen Logo des Teams.
    /// Anmerkung: Bisher identisch zum Logo-URL, aber könnte in Zukunft abweichen.
    /// </summary>
    [JsonPropertyName( "logo_small" )]
    public string? LogoSmall { get; set; }
}

/// <summary>
/// Ein Verein.
/// </summary>
public class SmV2Club
{
    /// <summary>
    /// Die ID des Vereins. (> 0)
    /// </summary>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Vollständiger Name des Vereins, z.B. "Floorball-Club München e. V.".
    /// </summary>
    [JsonPropertyName( "long_name" )]
    public string? LongName { get; set; }

    /// <summary>
    /// Name des Vereins, z.B. "Floorball-Club München".
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; }

    /// <summary>
    /// Kurzname des Vereins, z.B. "FBCM".
    /// </summary>
    [JsonPropertyName( "short_name" )]
    public string? ShortName { get; set; }

    /// <summary>
    /// Bundesland des Vereins im ISO 3166-2 Format.
    /// Siehe: https://de.wikipedia.org/wiki/ISO_3166-2:DE
    /// Beispiel: "de-by"
    /// </summary>
    [JsonPropertyName( "state" )]
    public string? State { get; set; }

    /// <summary>
    /// Url zum Logo des Vereins.
    /// </summary>
    [JsonPropertyName( "logo_url" )]
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Url zum kleinen Logo des Vereins.
    /// Anmerkung: Bisher identisch zum Logo-URL, aber könnte in Zukunft abweichen.
    /// </summary>
    [JsonPropertyName( "logo_small_url" )]
    public string? LogoSmallUrl { get; set; }

    /// <summary>
    /// Id des Verbandes, in dem der Verein spielt.
    /// </summary>
    [JsonPropertyName( "game_operation_id" )]
    public int? GameOperationId { get; set; }

    /// <summary>
    /// Id anderer Spielbetriebe, in denen der Verein spielt., z.B. in einem Pokalwettbewerb.
    /// </summary>
    [JsonPropertyName( "additional_game_operation_ids" )]
    public ICollection<int?>? AdditionalGameOperationIds { get; set; } = [];
}
