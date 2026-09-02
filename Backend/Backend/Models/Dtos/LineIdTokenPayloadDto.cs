using System.Text.Json.Serialization;

namespace Backend.Models.Dtos
{
    public class LineIdTokenPayloadDto
    {
        [JsonPropertyName("sub")]
        public string Sub { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("picture")]
        public string? Picture { get; set; }
    }
}
