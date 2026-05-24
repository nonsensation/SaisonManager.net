namespace Unihockey.Saisonmanager.Domain.SmV2;


using System.Text.Json.Serialization;

using Unihockey.Common.JsonConverters;


/// <summary>
/// Wird als Basis für Spieler-Objekte verwendet, z.B. in TeamPlayer, StartingPlayer, AwardPlayer.
/// </summary>
[JsonPolymorphic( TypeDiscriminatorPropertyName = "$type" , UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor )]
[JsonDerivedType( typeof( SmV2TeamPlayer ) , nameof( SmV2TeamPlayer ) )]
[JsonDerivedType( typeof( SmV2AwardPlayer ) , nameof( SmV2AwardPlayer ) )]
[JsonDerivedType( typeof( SmV2StartingPlayer ) , nameof( SmV2StartingPlayer ) )]
public abstract class SmV2BasePlayer
{
    /// <summary>
    /// Die ID des Spielers.
    /// </summary>
    [JsonConverter( typeof( IntStringConverter ) )]
    [JsonPropertyName( "player_id" )]
    public int? PlayerId { get; set; }

    /// <summary>
    /// Trikotnummer des Spielers.
    /// Von #1 (Goalies vorbehalten) bis #99.
    /// </summary>
    [JsonConverter( typeof( IntStringConverter ) )]
    [JsonPropertyName( "trikot_number" )]
    public int? TrikotNumber { get; set; }

    /// <summary>
    /// Nachname des Spielers.
    /// </summary>
    [JsonPropertyName( "player_name" )]
    public string? PlayerName { get; set; }

    /// <summary>
    /// Vorname des Spielers.
    /// </summary>
    [JsonPropertyName( "player_firstname" )]
    public string? PlayerFirstname { get; set; }

    /// <summary>
    /// Dummy-Feld
    /// Anmerkung: In Spiel #35372 'players.home' hat 'plaayer_name', daher dieses Dummy-Feld
    /// </summary>
    [JsonPropertyName( "plaayer_name" )]
    public string? unusedPlaayerName { get; set; }
}
