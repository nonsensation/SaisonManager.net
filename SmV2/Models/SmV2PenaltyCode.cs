namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/user/leagues/penalty_codes.json

/// <summary>
/// Strafcode, der aktuell vergeben werden kann.
/// Dies kann sich je nach Regeländerung unterscheiden.
/// </summary>
// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmPenaltyCodesResponse ) , nameof( SmPenaltyCodesResponse ) )]
public class SmV2PenaltyCode
{
    /// <summary>
    /// Zahlencode der Strafe.
    /// Wird von IFF/FVD vergeben.
    /// Kann sich je nach Regeländerung unterscheiden (2026 wird es die nächste Anpassung geben).
    /// Wird auf Spielberichtsbogen verwendet.
    /// </summary>
    [JsonPropertyName( "code" )]
    public string? Code { get; set; }

    /// <summary>
    /// Ob der Strafcode aktuell aktiv ist.
    /// Bisher sind alle aktiv.
    /// </summary>
    [JsonPropertyName( "active" )]
    public bool? Active { get; set; }

    /// <summary>
    /// Beschreibung des Verstoßes.
    /// </summary>
    [JsonPropertyName( "description" )]
    public string? Description { get; set; }

    /// <summary>
    /// Unbekannt, ggf SM-interne ID.
    /// </summary>
    [JsonPropertyName( "id" )]
    public string? Id { get; set; }
}
