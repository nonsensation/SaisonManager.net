using System.Collections;
using System.Security.Cryptography;
using System.Text;


public sealed class Hash
{
    public string HashString { get; } = string.Empty;
    public byte[] HashBytes { get; } = [];

    public Hash( string content )
    {
        ArgumentException.ThrowIfNullOrEmpty( content );

        var hashBytes = SHA256.HashData( Encoding.UTF8.GetBytes( content ) );

#pragma warning disable CA1872 // Prefer 'System.Convert.ToHexStringLower(byte[])' over call chains based on 'System.BitConverter.ToString(byte[])'
#pragma warning disable CA1308 // In method '.ctor', replace the call to 'ToLowerInvariant' with 'ToUpperInvariant'
        var hashString = BitConverter.ToString( hashBytes )
            .Replace( "-" , "" , StringComparison.InvariantCulture )
            .ToLowerInvariant();
#pragma warning restore CA1872
#pragma warning restore CA1308

        HashBytes = hashBytes;
        HashString = hashString;
    }

    public string ShortHashString( int length = 8 )
    {
        return HashString.Substring( 0 , Math.Min( length , HashString.Length ) );
    }
}
