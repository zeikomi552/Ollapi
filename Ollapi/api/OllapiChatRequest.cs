using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollapi.api
{
    public class OllapiChatRequest : OllapiRequest
    {
        /// <summary>
        /// uri
        /// </summary>
        public string Uri { get; private set; } = string.Empty;
        /// <summary>
        /// Endpoint
        /// </summary>
        private string Endpoint = "/api/chat";
        /// <summary>
        /// Model name for ollama
        /// </summary>
        public string Model { get; set; } = string.Empty;

        public string Role { get; set; } = "user";

        public string Content {  get; set; } = string.Empty;


        [JsonPropertyName("message")]
        public OllapiMessage? Message { get; set; } = new OllapiMessage();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="port">port number</param>
        /// <param name="model">modelname</param>
        public OllapiChatRequest(string host, int port, string model)
        {
            this.Uri = "http://" + host + ":" + port.ToString();
            this.Model = model;
        }


        /// <summary>
        /// Request for generate endpoint
        /// </summary>
        /// <returns></returns>
        public async Task<string> Request(List<KeyValuePair<string, string>> roleAndContentHistory)
        {
            if (this.Message != null)
            {
                var query = GetQuery(roleAndContentHistory);
                return await base.Post(this.Uri + this.Endpoint, query);
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetQuery(List<KeyValuePair<string, string>> roleAndContentHistory)
        {
            StringBuilder query = new StringBuilder();

            query.Append("{");

            if (!string.IsNullOrEmpty(this.Model))
                query.Append($"\"model\": \"{this.Model}\", ");

            if (this.Message != null)
            {
                query.Append($"\"messages\": [");

                int index = 0;
                foreach (var item in roleAndContentHistory)
                {
                    if (index != 0)
                    {
                        query.Append(",");
                    }
                    query.Append($"{{ \"role\": \"{item.Key}\", \"content\": \"{item.Value.Replace("\r", "").Replace("\n","")}\" }}");
                    index++;
                }
                query.Append("],");
            }
            query.Append($"\"stream\": false");
            query.Append("}");

            return query.ToString();
        }
    }
}
