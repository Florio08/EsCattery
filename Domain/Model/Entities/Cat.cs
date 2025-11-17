using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public enum Sex
    {
        Male,Female
    }
    public class Cat
    {
        public Cat(string name,string race,Sex sex,string description, DateOnly? birth,DateOnly arrived,DateOnly? left,string? catImage,string? cui)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name cannot be null or empty", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(race))
            {
                throw new ArgumentException("race cannot be null or empty", nameof(race));
            }
            Name = name;
            Race = race;
            CatSex = sex;
            if(string.IsNullOrWhiteSpace(description))
            {
                description = "No description";//almeno evito di throware sempre errori.
            }
            Description = description;
            Birth = birth;
            ArrivedToCattery = arrived;
            Birth = birth;
            LeftCattery = left;
            CatImage = catImage;
            //genero un numero casuale di 5 cifre
            if (!string.IsNullOrWhiteSpace(cui))
            {
                Cui = cui;
            }
            else
            {
                Generate();
            }
        }
        public void Generate()
        {
            Random random = new Random();
            int cuiNumber = random.Next(10000, 99999);
            //prima lettera del mese
            string monthLetter = ArrivedToCattery.Month.ToString().First().ToString().ToUpper();
            //anno
            string year = ArrivedToCattery.Year.ToString();
            //tre lettere casuali
            List<char> letters = new List<char>();
            for (int i = 0; i < 3; i++)
            {
                letters.Add((char)(random.Next(65, 90)));
            }
            //unisco tutto
            Cui = $"{cuiNumber}{monthLetter}{year}{letters[0]}{letters[1]}{letters[2]}";
        }
        public override bool Equals(object? obj)//uguali se hanno lo stesso cui
        {
            if (obj is Cat)
            {
                Cat other = (Cat)obj;
                return this.Cui == other.Cui;
            }
            return false;
        }
        public string Name { get; private set; }
        public string Race { get; private set; }
        public Sex CatSex { get; private set; }
        public DateOnly? Birth { get; private set; }
        public DateOnly ArrivedToCattery { get; private set; }
        public DateOnly? LeftCattery { get; set; }
        public string Description { get; set; }
        public string Cui { get; private set; }
        public string? CatImage { get;  set; }
    }
}
