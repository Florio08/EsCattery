using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using Application.Mappers;
using Application.UseCases;
using Application.Interfaces;
using Domain.Model.Entities;
using Domain.Model.ValueObject;

namespace Application.Tests
{
    [TestClass]
    public class AddressDto_Tests
    {
        [TestMethod]
        public void AddressDto_Ctor_ConValoriValidi_ImpostaStreet()
        {
            var dto = new AddressDto("Via Roma", "Milano", "20100", "Italia");
            Assert.AreEqual("Via Roma", dto.Street);
        }

        [TestMethod]
        public void AddressDto_Ctor_ConValoriValidi_ImpostaCity()
        {
            var dto = new AddressDto("Via Roma", "Milano", "20100", "Italia");
            Assert.AreEqual("Milano", dto.City);
        }

        [TestMethod]
        public void AddressDto_Ctor_ConValoriValidi_ImpostaPostalCode()
        {
            var dto = new AddressDto("Via Roma", "Milano", "20100", "Italia");
            Assert.AreEqual("20100", dto.PoscalCode);
        }

        [TestMethod]
        public void AddressDto_Ctor_ConValoriValidi_ImpostaCountry()
        {
            var dto = new AddressDto("Via Roma", "Milano", "20100", "Italia");
            Assert.AreEqual("Italia", dto.Country);
        }
    }

    // AdopterDto_Tests
    [TestClass]
    public class AdopterDto_Tests
    {
        private readonly AddressDto _address = new("Via Roma", "Milano", "20100", "Italia");
        private readonly PhoneNumberDto _phone = new("3331234567");
        private readonly FiscalCodeDto _fiscal = new("RSSMRA80A01H501U");
        private readonly EmailDto _email = new ("mario@rossi.it");

        [TestMethod]
        public void AdopterDto_Ctor_ConValoriValidi_ImpostaNome()
        {
            var dto = new AdopterDto("Mario", "Rossi", _address, _phone, _fiscal, _email);
            Assert.AreEqual("Mario", dto.Name);
        }

        [TestMethod]
        public void AdopterDto_Ctor_ConValoriValidi_ImpostaCognome()
        {
            var dto = new AdopterDto("Mario", "Rossi", _address, _phone, _fiscal, _email);
            Assert.AreEqual("Rossi", dto.Surname);
        }

        [TestMethod]
        public void AdopterDto_Ctor_ConValoriValidi_ImpostaIndirizzo()
        {
            var dto = new AdopterDto("Mario", "Rossi", _address, _phone, _fiscal, _email);
            Assert.AreEqual(_address, dto.Address);
        }

        [TestMethod]
        public void AdopterDto_Ctor_ConValoriValidi_ImpostaNumeroTelefono()
        {
            var dto = new AdopterDto("Mario", "Rossi", _address, _phone, _fiscal, _email);
            Assert.AreEqual(_phone, dto.CelNumber);
        }

        [TestMethod]
        public void AdopterDto_Ctor_ConValoriValidi_ImpostaCodiceFiscale()
        {
            var dto = new AdopterDto("Mario", "Rossi", _address, _phone, _fiscal, _email);
            Assert.AreEqual(_fiscal, dto.AdopterFiscalCode);
        }

        [TestMethod]
        public void AdopterDto_Ctor_ConValoriValidi_ImpostaEmail()
        {
            var dto = new AdopterDto("Mario", "Rossi", _address, _phone, _fiscal, _email);
            Assert.AreEqual("mario@rossi.it", dto.AdopterEmail.Email);
        }
    }

    // AdoptionDto_Tests

    [TestClass]
    public class AdoptionDto_Tests
    {
        private readonly CatDto _cat = new("Micio", "Europeo", new SexDto("male"), "Dolce",
            new DateOnly(2020, 1, 1), new DateOnly(2021, 1, 1), null, null, null);
        private readonly AdopterDto _adopter = new("Mario", "Rossi",
            new AddressDto("Via Roma", "Milano", "20100", "Italia"),
            new PhoneNumberDto("3331234567"),
            new FiscalCodeDto("RSSMRA80A01H501U"),
            new EmailDto("mario@rossi.it"));
        private readonly DateOnly _date = new(2024, 6, 1);

        [TestMethod]
        public void AdoptionDto_Ctor_ConValoriValidi_ImpostaCat()
        {
            var dto = new AdoptionDto(_cat, _adopter, _date);
            Assert.AreEqual(_cat, dto.Cat);
        }

        [TestMethod]
        public void AdoptionDto_Ctor_ConValoriValidi_ImpostaAdopter()
        {
            var dto = new AdoptionDto(_cat, _adopter, _date);
            Assert.AreEqual(_adopter, dto.Adopter);
        }

        [TestMethod]
        public void AdoptionDto_Ctor_ConValoriValidi_ImpostaData()
        {
            var dto = new AdoptionDto(_cat, _adopter, _date);
            Assert.AreEqual(_date, dto.Date);
        }
    }

    // CatDto_Tests
    [TestClass]
    public class CatDto_Tests
    {
        private readonly SexDto _sex = new("female");

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaNome()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual("Micia", dto.Name);
        }

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaRazza()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual("Persiano", dto.Race);
        }

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaSesso()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual(_sex, dto.sex);
        }

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaDescrizione()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual("Tranquilla", dto.Description);
        }

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaDataNascita()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual(new DateOnly(2019, 5, 10), dto.Birth);
        }

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaDataArrivo()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual(new DateOnly(2020, 6, 1), dto.ArrivedToCattery);
        }

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaImmagine()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual("img.jpg", dto.CatImage);
        }

        [TestMethod]
        public void CatDto_Ctor_ConValoriValidi_ImpostaCui()
        {
            var dto = new CatDto("Micia", "Persiano", _sex, "Tranquilla",
                new DateOnly(2019, 5, 10), new DateOnly(2020, 6, 1), null, "img.jpg", "CUI123");
            Assert.AreEqual("CUI123", dto.Cui);
        }
    }

    // FiscalCodeDto_Tests
    [TestClass]
    public class FiscalCodeDto_Tests
    {
        [TestMethod]
        public void FiscalCodeDto_Ctor_ConValoreValido_ImpostaCodiceFiscale()
        {
            var dto = new FiscalCodeDto("RSSMRA80A01H501U");
            Assert.AreEqual("RSSMRA80A01H501U", dto.CF);
        }
    }

    // PhoneNumberDto_Tests
    [TestClass]
    public class PhoneNumberDto_Tests
    {
        [TestMethod]
        public void PhoneNumberDto_Ctor_ConValoreValido_ImpostaNumero()
        {
            var dto = new PhoneNumberDto("3331234567");
            Assert.AreEqual("3331234567", dto.Number);
        }
    }

    // SexDto_Tests
    [TestClass]
    public class SexDto_Tests
    {
        [TestMethod]
        public void SexDto_Ctor_ConValoreMaschile_ImpostaMale()
        {
            var dto = new SexDto("male");
            Assert.AreEqual("male", dto.Sex);
        }

        [TestMethod]
        public void SexDto_Ctor_ConValoreFemminile_ImpostaFemale()
        {
            var dto = new SexDto("female");
            Assert.AreEqual("female", dto.Sex);
        }
    }

    // AddressMapper_Tests
    [TestClass]
    public class AddressMapper_Tests
    {
        [TestMethod]
        public void AddressMapper_ToEntity_ConDtoValido_CreaEntityConStessoStreet()
        {
            var dto = new AddressDto("Via Roma", "Milano", "20100", "Italia");
            var entity = dto.ToEntity();
            Assert.AreEqual("Via Roma", entity.Street);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddressMapper_ToEntity_ConDtoNull_LanciaEccezione()
        {
            AddressDto dto = null;
            dto.ToEntity();
        }

        [TestMethod]
        public void AddressMapper_ToDto_ConEntityValido_CreaDtoConStessoStreet()
        {
            var entity = new Address("Via Roma", "Milano", "20100", "Italia");
            var dto = entity.ToDto();
            Assert.AreEqual("Via Roma", dto.Street);
        }
    }

    // AdopterMapper_Tests
    [TestClass]
    public class AdopterMapper_Tests
    {
        [TestMethod]
        public void AdopterMapper_ToEntity_ConDtoValido_CreaEntityConEmail()
        {
            var dto = new AdopterDto("Mario", "Rossi",
                new AddressDto("Via Roma", "Milano", "20100", "Italia"),
                new PhoneNumberDto("+393331234567"),
                new FiscalCodeDto("RSSMRA80A01H501U"),
                new EmailDto("mario@rossi.it"));

            var entity = dto.ToEntity();
            Assert.AreEqual("mario@rossi.it", entity.AdopterEmail.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdopterMapper_ToEntity_ConDtoNull_LanciaEccezione()
        {
            AdopterDto dto = null;
            dto.ToEntity();
        }

        [TestMethod]
        public void AdopterMapper_ToDto_ConEntityValido_CreaDtoConEmail()
        {
            var entity = new Adopter("Mario", "Rossi",
                new Address("Via Roma", "Milano", "20100", "Italia"),
                new PhoneNumber("+393331234567"),
                new FiscalCode("RSSMRA80A01H501U"),
                new Email("mario@rossi.it"));

            var dto = entity.ToDto();
            Assert.AreEqual("mario@rossi.it", dto.AdopterEmail.Email);
        }
    }

    // CatMapper_Tests
    [TestClass]
    public class CatMapper_Tests
    {
        [TestMethod]
        public void CatMapper_ToEntity_ConDtoValido_CreaEntityConNome()
        {
            var dto = new CatDto("Micio", "Europeo", new SexDto("male"), "Dolce",
                new DateOnly(2020, 1, 1), new DateOnly(2021, 1, 1), null, "img.jpg", "CUI123");
            var entity = dto.ToEntity();
            Assert.AreEqual("Micio", entity.Name);
        }
    }

    // FiscalCodeMapper_Tests
    [TestClass]
    public class FiscalCodeMapper_Tests
    {
        [TestMethod]
        public void FiscalCodeMapper_ToEntity_ConDtoValido_CreaEntityConCF()
        {
            var dto = new FiscalCodeDto("RSSMRA80A01H501U");
            var entity = dto.ToEntity();
            Assert.AreEqual("RSSMRA80A01H501U", entity.CF);
        }
    }

}
