using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Core.ValueObjects
{
    internal class UserRole
    {
        internal string Name { get; private set; }
        internal int Id { get; private set; }

        private UserRole(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public static readonly UserRole Admin = new("Administrator", 1);
        public static readonly UserRole Manager = new("Manager", 2);
        public static readonly UserRole HrEmployee = new("Pracownik HR", 3);
        public static readonly UserRole Dispatcher = new("Spedytor", 4);
        public static readonly UserRole Driver = new("Kierowca", 5);
        public static readonly UserRole Mechanic = new("Mechanik", 6);
        public static readonly UserRole Invalid = new("Invalid", 100);

        public static UserRole FromString(string name)
        {
            return name.ToLower() switch
            {
                "admin" => Admin,
                "manager" => Manager,
                "hremployee" => HrEmployee,
                "dispatcher" => Dispatcher,
                "driver" => Driver,
                "mechanic" => Mechanic,
                _ => Invalid
            };
        }

        public override bool Equals(object? obj) => obj is UserRole other && other.Name == Name;
        public override int GetHashCode() => Name.GetHashCode();
    }
}
