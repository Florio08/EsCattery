using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Adoption
    {
        
        public Adoption(Cat cat, Adopter adopter,DateOnly date) 
        {
            AdoptionCat = cat;
            AdoptionAdopter = adopter;
            AdoptionDate = date;
        }
        public Cat AdoptionCat { get; private set; }
        public Adopter AdoptionAdopter { get; private set; }
        public DateOnly AdoptionDate { get; private set; }
        public override bool Equals(object? obj)
        {
            if (obj is Adoption)
            {
                return AdoptionCat.Equals(this.AdoptionCat) && AdoptionAdopter.Equals(this.AdoptionAdopter);
            }
            return false;
        }
    }
}
