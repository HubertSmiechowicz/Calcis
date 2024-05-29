using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Base.Core
{
    internal class Message
    {
        public string Name { get; set; }
        public string Value { get; set; }

        private Message() { }

        private Message(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public static Message CreateMessage(string Name, string Value)
        {
            return new Message(Name, Value);
        }
    }
}
