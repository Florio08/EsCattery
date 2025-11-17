using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Dto;
using System;
using Domain.Model.Entities;
using Domain.Model.ValueObject;
namespace testApplication
{
    [TestClass]
    public class AdopterDto_Tests
    {
        private readonly AddressDto _address = new("Via Roma", "Milano", "20100", "Italia");
        private readonly PhoneNumberDto _phone = new("3331234567");
        private readonly FiscalCodeDto _fiscal = new("RSSMRA80A01H501U");
        private readonly EmailDto _email = new EmailDto("mario@rossi.it");

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
}
