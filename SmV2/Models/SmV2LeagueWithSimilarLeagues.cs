namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/leagues/1396.json


/// <summary>
/// Liga mit ähnlichen Ligen.
/// Anmerkung: wird in der Antwort auf die Anfrage einer einzelnen Liga zurückgegeben.
/// </summary>
// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmLeagueResponse ) , nameof( SmLeagueResponse ) )]
public class SmV2LeagueWithSimilarLeagues : SmV2League
{
    /// <summary>
    /// Liste von Ligen, die der Liga ähnlich sind.
    /// Anmerkung: anstatt IDs, sind hier die vollständigen Ligen-Objekte enthalten.
    /// </summary>
    [JsonPropertyName( "similar_leagues" )]
    public ICollection<SmV2League> SimilarLeagues { get; } = [];
}

