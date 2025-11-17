using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.ValueObject;
using Domain.Model.Entities;

namespace TestDomain
{

    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void metodo_IndirizzoValido_ToStringContieneCampi()
        {
            var address = new Address("via Roma 1", "Milano", "20100", "Italia");

            var str = address.ToString();

            Assert.AreEqual("via Roma 1, Milano, 20100, Italia", str);
        }

        [TestMethod]
        public void metodo_EmailInvalida_LancioArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Email("indirizzo-senza-at"));
        }

        [TestMethod]
        public void metodo_CodiceFiscaleValido_VieneAssegnato()
        {
            string cfValue = "ABCDEF12G34H567I"; // 6 lettere,2 cifre,1 lettera,2 cifre,1 lettera,3 cifre,1 lettera

            var fiscal = new FiscalCode(cfValue);

            Assert.AreEqual(cfValue, fiscal.CF);
        }

        [TestMethod]
        public void metodo_TelefonoValido_VieneAssegnato()
        {
            string number = "+391234567890";

            var phone = new PhoneNumber(number);

            Assert.AreEqual(number, phone.Number);
        }

        [TestMethod]
        public void metodo_CatValido_NomeAssegnato()
        {
            var arrived = DateOnly.FromDateTime(DateTime.Today);
            var cat = new Cat("Micio", "Europeo", Sex.Male, "Gatto allegro", null, arrived, null, null);

            Assert.AreEqual("Micio", cat.Name);
        }

        [TestMethod]
        public void metodo_AdopterConStessoCodiceFiscale_SonoUguali()
        {
            var address = new Address("via Milano 2", "Roma", "00100", "Italia");
            var phone = new PhoneNumber("+39 1234567");
            var email = new Email("prova@example.com");
            var cf = new FiscalCode("ABCDEF12G34H567I");

            var adopter1 = new Adopter("Luca", "Rossi", address, phone, cf, email);
            var adopter2 = new Adopter("Marco", "Bianchi", address, phone, cf, email);

            Assert.IsTrue(adopter1.Equals(adopter2));
        }

        [TestMethod]
        public void metodo_AdoptionDataImpostata_DataCorretta()
        {
            var arrived = DateOnly.FromDateTime(DateTime.Today);
            var cat = new Cat("Pulce", "Siamese", Sex.Male, "Descrizione", null, arrived, null, null);

            var address = new Address("via Verdi 3", "Torino", "10100", "Italia");
            var phone = new PhoneNumber("+39 987654321");
            var email = new Email("adopt@example.com");
            var cf = new FiscalCode("ZYXWVU12A34B567C");

            var adopter = new Adopter("Anna", "Neri", address, phone, cf, email);

            var adoptionDate = DateOnly.FromDateTime(new DateTime(2024, 1, 1));
            var adoption = new Adoption(cat, adopter, adoptionDate);

            Assert.AreEqual(adoptionDate, adoption.AdoptionDate);
        }
    }
}
