using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollapi.api
{
    public class OllapiChatResponse
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public OllapiMessage? Message { get; set; }

        [JsonPropertyName("done")]
        public bool Done { get; set; }

        [JsonPropertyName("total_duration")]
        public int TotalDuration {  get; set; }
        
        [JsonPropertyName("load_duration")]
        public int LoadDuration {  get; set; }
        
        [JsonPropertyName("prompt_eval_count")]
        public int PromptEvalCount {  get; set; }
        
        [JsonPropertyName("prompt_eval_duration")]
        public int PromptEvalDuration {  get; set; }
        
        [JsonPropertyName("eval_count")]
        public int EvalCount {  get; set; }
        
        [JsonPropertyName("eval_duration")]
        public int EvalDuration { get; set; }
    }
}
