using Microsoft.VisualStudio.TestTools.UnitTesting;
using Habilitations.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habilitations.connexion;
using Habilitations.modele;

namespace Habilitations.dal.Tests
{
    [TestClass()]
    public class AccesDonneesTests
    {
        /// <summary>
        /// chaine de connexion à la bdd
        /// </summary>
        private static readonly string connectionString = "server=localhost;user id=habilitations;password=motdepasseuser;database=habilitations;SslMode=none";

        /// <summary>
        /// connexion à la bdd
        /// </summary>
        private readonly ConnexionBdd bdd = ConnexionBdd.GetInstance(connectionString);

        /// <summary>
        /// désactive autocommit et démarre transaction
        /// </summary>
        private void BeginTransaction()
        {
            bdd.ReqUpdate("SET AUTOCOMMIT = 0;", null);
            bdd.ReqUpdate("START TRANSACTION;", null);
        }

        /// <summary>
        /// rollback en fin de transaction
        /// </summary>
        private void EndTransaction()
        {
            bdd.ReqUpdate("ROLLBACK;", null);
        }

        /// <summary>
        /// Enlever les contraintes
        /// </summary>
        private void CancelConstraints()
        {
            bdd.ReqUpdate("SET FOREIGN_KEY_CHECKS=0", null);
        }

        /// <summary>
        /// Remettre les contraintes
        /// </summary>
        private void ResetConstraints()
        {
            bdd.ReqUpdate("SET FOREIGN_KEY_CHECKS=1", null);
        }

        [TestMethod()]
        public void ControleAuthentificationTest()
        {
            string nom = "Nolan";
            string prenom = "Rooney";
            string pwd = "Nolan";
            Assert.AreEqual(true, AccesDonnees.ControleAuthentification(nom, prenom, pwd), "devrait réussir, données correctes");
            string erreurNom = "Jean";
            string erreurPrenom = "Jean";
            string erreurPwd = "Jean";
            Assert.AreEqual(false, AccesDonnees.ControleAuthentification(nom, prenom, erreurPwd), "devrait échouer, pwd incorrect");
            Assert.AreEqual(false, AccesDonnees.ControleAuthentification(nom, erreurPrenom, pwd), "devrait échouer, prénom incorrect");
            Assert.AreEqual(false, AccesDonnees.ControleAuthentification(erreurNom, prenom, pwd), "devrait échouer, nom incorrect");
        }

        [TestMethod()]
        public void GetLesDeveloppeursTest()
        {
            List<Developpeur> lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
            Assert.IsTrue(lesDeveloppeurs.Count > 0, "devrait réussir");
        }

        [TestMethod()]
        public void GetLesProfilsTest()
        {
            List<Profil> lesProfils = AccesDonnees.GetLesProfils();
            Assert.IsTrue(lesProfils.Count > 0, "devrait réussir");
        }

        [TestMethod()]
        public void DelDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
            int nbDeveloppeurs = lesDeveloppeurs.Count;
            if (nbDeveloppeurs > 0)
            {
                Developpeur devDelete = lesDeveloppeurs[0];
                AccesDonnees.DelDeveloppeur(devDelete);
                lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
                int nbDeveloppeursAfterDelete = lesDeveloppeurs.Count;
                Developpeur notFound = lesDeveloppeurs.Find(dev => dev.Iddeveloppeur.Equals(devDelete.Iddeveloppeur));
                Assert.IsNull(notFound, "devrait réussir, développeur non trouvé car supprimé");
                Assert.AreEqual(nbDeveloppeurs - 1, nbDeveloppeursAfterDelete, "devrait réussir, un dev en moins");
            }
            EndTransaction();

        }

        [TestMethod()]
        public void DelProfilTest()
        {
            BeginTransaction();
            CancelConstraints();

            List<Profil> lesProfils = AccesDonnees.GetLesProfils();
            int nbProfils = lesProfils.Count;
            if (nbProfils > 0)
            {
                Profil profilDelete = lesProfils[0];
                AccesDonnees.DelProfil(profilDelete);
                lesProfils = AccesDonnees.GetLesProfils();
                int nbProfilsAfterDelete = lesProfils.Count;
                Profil notFound = lesProfils.Find(profil => profil.Idprofil.Equals(profilDelete.Idprofil));
                Assert.IsNull(notFound, "devrait réussir, profil non trouvé car supprimé");
                Assert.AreEqual(nbProfils - 1, nbProfilsAfterDelete, "devrait réussir, un profil en moins");

            }
            ResetConstraints();
            EndTransaction();
        }

        [TestMethod()]
        public void AddDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
            int nbDeveloppeurs = lesDeveloppeurs.Count;

            string nom = "newNom";
            string prenom = "newPrenom";
            string tel = "newTel";
            string mail = "newMail";
            int idProfil = 3;
            string profil = "front-dev";
            Developpeur nouveauDev = new Developpeur(0, nom, prenom, tel, mail, idProfil, profil);

            AccesDonnees.AddDeveloppeur(nouveauDev);
            lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
            int nouveauNbDeveloppeurs = lesDeveloppeurs.Count;

            Developpeur newDev = lesDeveloppeurs.Find(dev => dev.Nom.Equals(nom)
                && dev.Prenom.Equals(prenom)
                && dev.Tel.Equals(tel)
                && dev.Mail.Equals(mail)
                && dev.Idprofil.Equals(idProfil)
            );
            Assert.IsNotNull(newDev, "devrait réussir, nouveau dev inséré");
            Assert.AreEqual(nbDeveloppeurs + 1, nouveauNbDeveloppeurs, "devrait réussir, un nouveau dev ajouté");
            EndTransaction();
        }

        [TestMethod()]
        public void AddProfilTest()
        {
            BeginTransaction();
            List<Profil> lesProfils = AccesDonnees.GetLesProfils();
            int nbProfils = lesProfils.Count;

            string nom = "nouveauprofil";
            Profil nouveauProfil = new Profil(0, nom);

            AccesDonnees.AddProfil(nouveauProfil);
            lesProfils = AccesDonnees.GetLesProfils();
            int nouveauNbProfils = lesProfils.Count;

            Profil newProfil = lesProfils.Find(profil => profil.Nom.Equals(nom));
            Assert.IsNotNull(newProfil, "devrait réussir, nouveau profil inséré");
            Assert.AreEqual(nbProfils + 1, nouveauNbProfils, "devrait réussir, un nouveau profil ajouté");
            EndTransaction();

        }

        [TestMethod()]
        public void UpdateDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
            int nbDeveloppeurs = lesDeveloppeurs.Count;
            if (nbDeveloppeurs > 0)
            {
                Developpeur developpeur = lesDeveloppeurs[0];
                int id = developpeur.Iddeveloppeur;
                string nom = "newNom";
                string prenom = "newPrenom";
                string tel = "newTel";
                string mail = "newMail";
                int idProfil = 3;
                string profil = "front-dev";
                Developpeur modifDev = new Developpeur(id, nom, prenom, tel, mail, idProfil, profil);

                AccesDonnees.UpdateDeveloppeur(modifDev);
                lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
                int nouveauNbDeveloppeurs = lesDeveloppeurs.Count;

                Developpeur newDev = lesDeveloppeurs.Find(dev => dev.Iddeveloppeur.Equals(id));
                if (newDev != null)
                {
                    bool modifOk = newDev.Nom.Equals(nom)
                        && newDev.Prenom.Equals(prenom)
                        && newDev.Tel.Equals(tel)
                        && newDev.Mail.Equals(mail)
                        && newDev.Idprofil.Equals(idProfil);
                    Assert.AreEqual(true, modifOk, "devrait réussir, modifications correctes");
                }
                else
                {
                    Assert.Fail("Modification pas réussi");
                }
                Assert.AreEqual(nbDeveloppeurs, nouveauNbDeveloppeurs, "devrait réussir, même nombre de dev");
            }
            EndTransaction();
        }

        [TestMethod()]
        public void UpdatePwdTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = AccesDonnees.GetLesDeveloppeurs();
            if (lesDeveloppeurs.Count > 0)
            {
                string pwd = "newPwd";
                lesDeveloppeurs[0].Pwd = pwd;
                AccesDonnees.UpdatePwd(lesDeveloppeurs[0]);
                string req = "Select pwd from developpeur where iddeveloppeur=@iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@iddeveloppeur", lesDeveloppeurs[0].Iddeveloppeur }
                };
                bdd.ReqSelect(req, parameters);
                if (bdd.Read())
                {
                    Assert.AreEqual(GetStringSha256Hash(pwd), bdd.Field("pwd"), "devrait réussir, pwd correct");
                }
                else
                {
                    Assert.Fail("développeur pas trouvé");
                }
            }
            EndTransaction();
        }

        /// <summary>
        /// Transformation d'une chaîne avec SHA256 (pour le pwd)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string GetStringSha256Hash(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}