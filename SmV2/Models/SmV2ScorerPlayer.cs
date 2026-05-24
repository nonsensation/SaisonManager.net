namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;


// https://saisonmanager.de/api/v2/leagues/1396/scorer.json


/// <summary>
/// Beschreibung eines Spielers in einer Liga.
/// </summary>
// [JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
// [JsonDerivedType( typeof( SmLeagueScorerResponse ) , nameof( SmLeagueScorerResponse ) )]
public class SmV2ScorerPlayer
{
    /// <summary>
    /// Anzahl gespielter Spiele.
    /// </summary>
    [JsonPropertyName( "games" )]
    public int? Games { get; set; }

    /// <summary>
    /// Anzahl erzielter Tore.
    /// </summary>
    [JsonPropertyName( "goals" )]
    public int? Goals { get; set; }

    /// <summary>
    /// Anzahl erzielter Assists.
    /// </summary>
    [JsonPropertyName( "assists" )]
    public int? Assists { get; set; }

    /// <summary>
    /// Anzahl von 2' Strafen.
    /// </summary>
    [JsonPropertyName( "penalty_2" )]
    public int? Penalty2 { get; set; }

    /// <summary>
    /// Anzahl von 2+2' Strafen.
    /// </summary>
    [JsonPropertyName( "penalty_2and2" )]
    public int? Penalty2and2 { get; set; }

    /// <summary>
    /// Anzahl von 5' Strafen.
    /// </summary>
    [JsonPropertyName( "penalty_5" )]
    public int? Penalty5 { get; set; }

    /// <summary>
    /// Anzahl von 10' Strafen.
    /// </summary>
    [JsonPropertyName( "penalty_10" )]
    public int? Penalty10 { get; set; }

    /// <summary>
    /// Anzahl von technischen Matchstrafen.
    /// </summary>
    [JsonPropertyName( "penalty_ms_tech" )]
    public int? PenaltyMsTech { get; set; }

    /// <summary>
    /// Anzahl von vollen Matchstrafen.
    /// </summary>
    [JsonPropertyName( "penalty_ms_full" )]
    public int? PenaltyMsFull { get; set; }

    /// <summary>
    /// Anzahl von Matchstrafen 1.
    /// </summary>
    [JsonPropertyName( "penalty_ms1" )]
    public int? PenaltyMs1 { get; set; }

    /// <summary>
    /// Anzahl von Matchstrafen 2.
    /// </summary>
    [JsonPropertyName( "penalty_ms2" )]
    public int? PenaltyMs2 { get; set; }

    /// <summary>
    /// Anzahl von Matchstrafen 3.
    /// </summary>
    [JsonPropertyName( "penalty_ms3" )]
    public int? PenaltyMs3 { get; set; }

    /// <summary>
    /// Id des Spielers.
    /// </summary>
    [JsonPropertyName( "player_id" )]
    public int? PlayerId { get; set; }

    /// <summary>
    /// Id des Teams, für das der Spieler spielt.
    /// </summary>
    [JsonPropertyName( "team_id" )]
    public int? TeamId { get; set; }

    /// <summary>
    /// Name des Teams, für das der Spieler spielt.
    /// </summary>
    [JsonPropertyName( "team_name" )]
    public string? TeamName { get; set; }

    /// <summary>
    /// Vorname des Spielers.
    /// </summary>
    [JsonPropertyName( "first_name" )]
    public string? FirstName { get; set; }

    /// <summary>
    /// Nachname des Spielers.
    /// </summary>
    [JsonPropertyName( "last_name" )]
    public string? LastName { get; set; }

    /// <summary>
    /// Bild des Spielers.
    /// Anmerkung: wird nicht verwendet (null). Daher Datentyp (url, binary data o.ä.) unklar.
    /// </summary>
    [JsonPropertyName( "image" )]
    public object? Image { get; set; }

    /// <summary>
    /// Kleines Bild des Spielers.
    /// Anmerkung: wird nicht verwendet (null). Daher Datentyp (url, binary data o.ä.) unklar.
    /// </summary>
    [JsonPropertyName( "image_small" )]
    public object? ImageSmall { get; set; }

    /// <summary>
    /// Sortierschlüssel für die Sortierung der Spieler in der Scorerliste.
    /// </summary>
    [JsonPropertyName( "sort" )]
    public int? Sort { get; set; }

    /// <summary>
    /// Posiion des Spielers in der Scorerliste.
    /// </summary>
    [JsonPropertyName( "position" )]
    public int? Position { get; set; }
}
