using System.Text.Json.Serialization;

namespace ClassLibrary1;

public class Places
{
    [JsonPropertyName("value")]
    public Dictionary<string, Place>? PlacesDictionary { get; set; }
}
