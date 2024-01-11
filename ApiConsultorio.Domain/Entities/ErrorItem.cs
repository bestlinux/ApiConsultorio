using System.Text.Json.Serialization;

namespace ApiConsultorio.Domain.Entities
{
    public class ErrorItem
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}
