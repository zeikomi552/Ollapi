using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollapi.api
{
    public class OllapiGenerateResponse
    {
        [JsonPropertyName("model")] 
        public string Model {  get; set; } = string.Empty;

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; } = string.Empty;

    }
}
