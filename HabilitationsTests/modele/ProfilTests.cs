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
    public class ProfilTests
    {
        private const int idprofil = 3;
        private const string nom = "front-dev";
        private readonly Profil profil = new Profil(idprofil, nom);

        [TestMethod()]
        public void ProfilTest()
        {
            Assert.AreEqual(idprofil, profil.Idprofil, "devrait réussir, idprofil correct");
            Assert.AreEqual(nom, profil.Nom, "devrait réussir, nom correct");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(nom, profil.ToString(), "devrait réussir, nom correct");
        }
    }
}