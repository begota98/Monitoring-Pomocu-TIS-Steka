using System.Text.Json.Serialization;

namespace API_Showcase.Models;

public class Point
{    
    [JsonPropertyName("timestamp")]
    public DateTime DateTime { get; set; }
    [JsonPropertyName("_field")]
    public string? Field { get; set; }
    [JsonPropertyName("value_type")]
    public string? ValueType { get; set; }
    [JsonPropertyName("_value")]
    public decimal? Value { get; set; }
}