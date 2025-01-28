using Ollapi.Interface;
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
        public IOllapiMessage? Message { get; set; }

        [JsonPropertyName("done")]
        public bool Done { get; set; }

        [JsonPropertyName("total_duration")]
        public Int64 TotalDuration {  get; set; }
        
        [JsonPropertyName("load_duration")]
        public Int64 LoadDuration {  get; set; }
        
        [JsonPropertyName("prompt_eval_count")]
        public Int64 PromptEvalCount {  get; set; }
        
        [JsonPropertyName("prompt_eval_duration")]
        public Int64 PromptEvalDuration {  get; set; }
        
        [JsonPropertyName("eval_count")]
        public Int64 EvalCount {  get; set; }
        
        [JsonPropertyName("eval_duration")]
        public Int64 EvalDuration { get; set; }
    }
}
