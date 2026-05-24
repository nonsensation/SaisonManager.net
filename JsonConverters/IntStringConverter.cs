namespace Unihockey.Common.JsonConverters;

using System.Text.Json;
using System.Text.Json.Serialization;

public class IntStringConverter : JsonConverter<int?>
{
    public override int? Read( ref Utf8JsonReader reader , Type typeToConvert , JsonSerializerOptions options )
    {
        switch( reader.TokenType )
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                {
                    if( reader.TryGetInt32( out var intValue ) )
                    {
                        return intValue;
                    }

                    break;
                }

            case JsonTokenType.String:
                {
                    var str = reader.GetString();

                    if( string.IsNullOrEmpty( str ) )
                    {
                        return null;
                    }
                    else if( int.TryParse( str , out var intValue ) )
                    {
                        return intValue;
                    }

                    break;
                }
        }

        throw new JsonException( $"Unable to convert to int?" );
    }

    public override void Write( Utf8JsonWriter writer , int? value , JsonSerializerOptions options )
    {
        if( value.HasValue )
        {
            writer.WriteNumberValue( value.Value );
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}