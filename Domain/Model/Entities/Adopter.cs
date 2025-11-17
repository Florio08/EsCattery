using Domain.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Adopter
    {
        public Adopter(string name, string surname, Address homeAddress, PhoneNumber celNumber,FiscalCode fiscalCode, Email email) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name cannot be null or empty", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentException("surname cannot be null or empty", nameof(surname));
            }
            
            Name = name;
            Surname = surname;
            HomeAddress = homeAddress;
            CelNumber = celNumber;
            AdopterFiscalCode = fiscalCode;
            AdopterEmail = email;
        }
        public override bool Equals(object? obj)//uguali se hanno lo stesso codice fiscale
        {
            if (obj is Adopter)
            {
                return ((Adopter)obj).AdopterFiscalCode.Equals(this.AdopterFiscalCode);
            }
            return false;
        }
        public Email AdopterEmail { get; private set; }
        public FiscalCode AdopterFiscalCode { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Address HomeAddress { get; private set; }
        public PhoneNumber CelNumber { get; private set; }
    }
}
