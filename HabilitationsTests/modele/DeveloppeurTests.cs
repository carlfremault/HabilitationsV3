using Microsoft.VisualStudio.TestTools.UnitTesting;
using Habilitations.modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habilitations.modele.Tests
{
    [TestClass()]
    public class DeveloppeurTests
    {
        private const int iddeveloppeur = 20;
        private const string nom = "JeanJean";
        private const string prenom = "Jean";
        private const string tel = "0123";
        private const string mail = "jean@jeanjean.fr";
        private const int idprofil = 3;
        private const string profil = "dev-front";
        private readonly Developpeur dev = new Developpeur(iddeveloppeur, nom, prenom, tel, mail, idprofil, profil);

        [TestMethod()]
        public void DeveloppeurTest()
        {
            Assert.AreEqual(iddeveloppeur, dev.Iddeveloppeur, "devrait réussir, iddeveloppeur correct");
            Assert.AreEqual(nom, dev.Nom, "devrait réussir, nom correct");
            Assert.AreEqual(prenom, dev.Prenom, "devrait réussir, prenom correct");
            Assert.AreEqual(tel, dev.Tel, "devrait réussir, tel correct");
            Assert.AreEqual(mail, dev.Mail, "devrait réussir, mail correct");
            Assert.AreEqual(idprofil, dev.Idprofil, "devrait réussir, idprofil correct");
            Assert.AreEqual(profil, dev.Profil, "devrait réussir, profil correct");

        }
    }
}