using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ollapi.Interface
{
    public interface IOllapiMessage
    {
        public string Role { get; set; }

        public string Content { get; set; }

        public string? Images { get; set; }
    }
}
