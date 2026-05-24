namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/leagues/1564/grouped_table.json

/// <summary>
/// Gruppe einer Tabelle, z.B. "Gruppe A", "Gruppe B" bei einer Liga mit Gruppenphase.
/// </summary>
// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmLeagueGroupedTableResponse ) , nameof( SmLeagueGroupedTableResponse ) )]
public class SmV2TableGroup
{
    /// <summary>
    /// Identifier der Gruppe, z.B. "group_a", "group_b". Wird in der API verwendet, um die Gruppen zu unterscheiden.
    /// </summary>
    [JsonPropertyName( "group_identifier" )]
    public string? Identifier { get; set; } = ""; // "group_a", "group_b" (see: GroupIdentifier)

    /// <summary>
    /// Name der Gruppe, z.B. "Gruppe A", "Gruppe B". Wird in der API angezeigt, um die Gruppen zu benennen.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string? Name { get; set; } = ""; // "Gruppe A"

    /// <summary>
    /// Liste der Teams in der Gruppe.
    /// Identisch zur Tabelle der Liga, aber nur mit den Teams der jeweiligen Gruppe.
    /// </summary>
    [JsonPropertyName( "table" )]
    public ICollection<SmV2TableTeam?>? Table { get; set; } = [];
}
