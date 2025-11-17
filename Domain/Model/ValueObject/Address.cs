using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Model.ValueObject
{
    public record Address
    {
        public string Street { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string Country { get; }

        public Address(string street, string city, string postalCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentException("street cannot be null or empty", nameof(street));
            }
            // Controlla che street inizi con "via" (case insensitive)
            if (!street.TrimStart().StartsWith("via", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("street must start with 'via'", nameof(street));
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("city cannot be null or empty", nameof(city));
            }

            if (string.IsNullOrWhiteSpace(postalCode))
            {
                throw new ArgumentException("postalCode cannot be null or empty", nameof(postalCode));
            }
            // Controlla che postalCode sia composto da esattamente 5 cifre
            if (!Regex.IsMatch(postalCode, @"^\d{5}$"))
            {
                throw new ArgumentException("postalCode must be exactly 5 digits", nameof(postalCode));
            }

            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException("country cannot be null or empty", nameof(country));
            }

            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
        public override string ToString()
        {
            return $"{Street}, {City}, {PostalCode}, {Country}";
        }
    }
}
