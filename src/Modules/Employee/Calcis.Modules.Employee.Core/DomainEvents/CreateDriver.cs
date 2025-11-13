using Calcis.Shared.Abstractions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Core.DomainEvents
{
    internal class CreateDriver : IDomainEvent
    {
        public Guid Id { get; set; }
    }
}
