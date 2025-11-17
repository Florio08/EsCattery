using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Model.ValueObject
{
    public record PhoneNumber
    {
        public PhoneNumber(string number) 
        {
            // Definisci una regex che verifica un prefisso internazionale (+39, +69, etc.) 
            // e un numero di telefono che può variare in lunghezza (ad esempio 9 cifre)
            string pattern = @"^\+(\d{2,3})\s?\d{6,12}$";

            // Verifica se la stringa corrisponde al pattern
            if( Regex.IsMatch(number, pattern))
            {
                Number = number;
            }
            else
            {
                throw new ArgumentException("Invalid phone number format", nameof(number));
            }
            
        }
        public string Number { get; private set; }
        public override string ToString()
        {
            return Number;
        }
    }
}
