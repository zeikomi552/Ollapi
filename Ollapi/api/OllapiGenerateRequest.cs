using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Ollapi.api
{
    /// <summary>
    /// Generate Request
    /// </summary>
    public class OllapiGenerateRequest : OllapiRequest
    {
        /// <summary>
        /// uri
        /// </summary>
        public string Uri { get; private set; }
        /// <summary>
        /// Endpoint
        /// </summary>
        private string Endpoint = "/api/generate";
        /// <summary>
        /// Model name for ollama
        /// </summary>
        public string Model { get; set; } = string.Empty;
        /// <summary>
        /// Prompt for ollama
        /// </summary>
        public string Prompt { get; set; } = string.Empty;
        /// <summary>
        /// Suffix
        /// </summary>
        public string Suffix { get; set; } = string.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="port">port number</param>
        /// <param name="model">modelname</param>
        public OllapiGenerateRequest(string host, int port, string model)
        {
            this.Uri = "http://" + host + ":" + port.ToString();
            this.Model = model;
        }

        /// <summary>
        /// Request for generate endpoint
        /// </summary>
        /// <returns></returns>
        public new  async Task<string> Request(string prompt)
        {
            this.Prompt = prompt;
            return await base.Post(this.Uri + this.Endpoint, this.Query);
        }

        /// <summary>
        /// request query
        /// </summary>
        private string Query
        {
            get
            {
                StringBuilder query = new StringBuilder();

                query.Append("{");

                if (!string.IsNullOrEmpty(this.Model))
                    query.Append($"\"model\": \"{this.Model}\", ");

                if (!string.IsNullOrEmpty(this.Prompt))
                    query.Append($"\"prompt\": \"{this.Prompt}\", ");
                query.Append($"\"stream\": false");
                query.Append("}");

                return query.ToString();
            }
        }
    }
}
