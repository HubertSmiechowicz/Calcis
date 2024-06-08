﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Application.Queries
{
    internal class Hello : IRequest<string>
    {
        public string Name { get; set; }
    }
}
