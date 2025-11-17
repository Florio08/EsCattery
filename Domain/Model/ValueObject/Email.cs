using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObject
{
    public record Email
    {
        public string Value { get; init; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Invalid email address.");
            }

            Value = value;
        }
    }
}