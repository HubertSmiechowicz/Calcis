using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Application.Commands.Models
{
    internal class KeycloakEvent
    {
        public string ResourceType { get; set; }
    }
}
