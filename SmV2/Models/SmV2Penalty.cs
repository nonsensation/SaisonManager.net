namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/user/leagues/penalties.json

/// <summary>
/// Strafen-Übersicht, die aktuell vergeben werden können.
/// Dies kann sich je nach Regeländerung unterscheiden.
/// </summary>
// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmPenaltiesResponse ) , nameof( SmPenaltiesResponse ) )]
public class SmV2Penalty
{
    /// <summary>
    /// Name der Strafe.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; }

    /// <summary>
    /// Sortierschlüssel der Strafe.
    /// Bisher unbenutzt/unbekannt.
    /// </summary>
    [JsonPropertyName( "order" )]
    public int? Order { get; set; }

    /// <summary>
    /// Mapping der Strafe.
    /// Wird in GameEvent verwendet.
    /// Siehe: <see cref="SmPenaltyType"/> 
    /// </summary>
    [JsonPropertyName( "mapping" )]
    public string? Mapping { get; set; }

    /// <summary>
    /// Längere Beschreibung. Kann null sein.
    /// </summary>
    [JsonPropertyName( "description" )]
    public string? Description { get; set; }

    /// <summary>
    /// Unbekannt, ggf SM-interne ID.
    /// </summary>
    [JsonPropertyName( "id" )]
    public string? Id { get; set; }
}
