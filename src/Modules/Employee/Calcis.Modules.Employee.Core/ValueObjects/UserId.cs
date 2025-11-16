using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calcis.Modules.Employee.Core.ValueObjects
{
    internal class UserId
    {
        private static readonly Regex _pattern = new(@"^users/(?<id>[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})$",
                                                   RegexOptions.Compiled);

        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId FromString(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("id cannot be null or empty", nameof(id));

            var succes = Guid.TryParse(id, out Guid guid);

            if (!succes)
                throw new ArgumentException($"Invalid GUID format: {id}");

            return new UserId(guid);
        }

        public static UserId FromResourcePath(string resourcePath)
        {
            if (string.IsNullOrWhiteSpace(resourcePath))
                throw new ArgumentException("resourcePath cannot be null or empty", nameof(resourcePath));

            var match = _pattern.Match(resourcePath);
            if (!match.Success)
                throw new ArgumentException($"Invalid resource path format: {resourcePath}");

            var guid = Guid.Parse(match.Groups["id"].Value);
            return new UserId(guid);
        }

        // Override Equals / GetHashCode
        public override bool Equals(object? obj) => Equals(obj as UserId);

        public bool Equals(UserId? other) => other != null && Value.Equals(other.Value);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"user/{Value}";
    }
}
