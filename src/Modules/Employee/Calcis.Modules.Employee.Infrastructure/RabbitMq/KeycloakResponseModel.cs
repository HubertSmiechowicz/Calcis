using Calcis.Modules.Employee.Application.Commands.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Infrastructure.RabbitMq
{
    internal class KeycloakResponseModel
    {
        [JsonProperty("operationType")]
        public string OperationType { get; set; }

        [JsonProperty("resourcePath")]
        public string ResourcePath { get; set; }

        [JsonProperty("representation")]
        public string RepresentationJson { get; set; }

        [JsonIgnore]
        public Representation? Representation =>
            !string.IsNullOrEmpty(RepresentationJson)
            ? JsonConvert.DeserializeObject<Representation>(RepresentationJson)
            : null;
    }
}
