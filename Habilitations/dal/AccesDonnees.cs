using Habilitations.connexion;
using Habilitations.modele;
using System;
using System.Collections.Generic;

namespace Habilitations.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les données distantes
    /// </summary>
    public static class AccesDonnees
    {
        /// <summary>
        /// chaine de connexion à la bdd
        /// </summary>
        private static readonly string connectionString = "server=localhost;user id=habilitations;password=motdepasseuser;database=habilitations;SslMode=none";

        /// <summary>
        /// Controle si l'utillisateur a le droit de se connecter (nom, prénom, pwd est profil "admin")
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static Boolean ControleAuthentification(string nom, string prenom, string pwd)
        {
            string req = "select * from developpeur d join profil p on d.idprofil=p.idprofil ";
            req += "where d.nom=@nom and d.prenom=@prenom and pwd=SHA2(@pwd, 256) and p.nom='admin';";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@nom", nom },
                { "@prenom", prenom },
                { "@pwd", pwd }
            };
            ConnexionBdd curs = ConnexionBdd.GetInstance(connectionString);
            curs.ReqSelect(req, parameters);
            if (curs.Read())
            {
                curs.Close();
                return true;
            }
            else
            {
                curs.Close();
                return false;
            }
        }

        /// <summary>
        /// Récupère et retourne les développeurs provenant de la BDD
        /// </summary>
        /// <returns>liste des développeurs</returns>
        public static List<Developpeur> GetLesDeveloppeurs()
        {
            List<Developpeur> lesDeveloppeurs = new List<Developpeur>();
            string req = "select d.iddeveloppeur as iddeveloppeur, d.nom as nom, d.prenom as prenom, d.tel as tel, d.mail as mail, p.idprofil as idprofil, p.nom as profil ";
            req += "from developpeur d join profil p on (d.idprofil = p.idprofil) ";
            req += "order by nom, prenom;";
            ConnexionBdd curs = ConnexionBdd.GetInstance(connectionString);
            curs.ReqSelect(req, null);
            while (curs.Read())
            {
                Developpeur developpeur = new Developpeur((int)curs.Field("iddeveloppeur"), (string)curs.Field("nom"), (string)curs.Field("prenom"), (string)curs.Field("tel"), (string)curs.Field("mail"), (int)curs.Field("idprofil"), (string)curs.Field("profil"));
                lesDeveloppeurs.Add(developpeur);
            }
            curs.Close();
            return lesDeveloppeurs;
        }

        /// <summary>
        /// Récupère et retourne les profils provenant de la BDD
        /// </summary>
        /// <returns>liste des profils</returns>
        public static List<Profil> GetLesProfils()
        {
            List<Profil> lesProfils = new List<Profil>();
            string req = "select * from profil order by nom;";
            ConnexionBdd curs = ConnexionBdd.GetInstance(connectionString);
            curs.ReqSelect(req, null);
            while (curs.Read())
            {
                Profil profil = new Profil((int)curs.Field("idprofil"), (string)curs.Field("nom"));
                lesProfils.Add(profil);
            }
            curs.Close();
            return lesProfils;
        }

        /// <summary>
        /// Suppression d'un développeur
        /// </summary>
        /// <param name="developpeur">objet developpeur à supprimer</param>
        public static void DelDeveloppeur(Developpeur developpeur)
        {
            string req = "delete from developpeur where iddeveloppeur = @iddeveloppeur;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@iddeveloppeur", developpeur.Iddeveloppeur }
            };
            ConnexionBdd conn = ConnexionBdd.GetInstance(connectionString);
            conn.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Suppression d'un profil
        /// </summary>
        /// <param name="profil"></param>
        public static void DelProfil(Profil profil)
        {
            string req = "delete from profil where idprofil = @idprofil;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@idprofil", profil.Idprofil }
            };
            ConnexionBdd conn = ConnexionBdd.GetInstance(connectionString);
            conn.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Ajoute un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public static void AddDeveloppeur(Developpeur developpeur)
        {
            string req = "insert into developpeur(nom, prenom, tel, mail, pwd, idprofil) ";
            req += "values (@nom, @prenom, @tel, @mail, @pwd, @idprofil);";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@nom", developpeur.Nom },
                { "@prenom", developpeur.Prenom },
                { "@tel", developpeur.Tel },
                { "@mail", developpeur.Mail },
                { "@pwd", GetStringSha256Hash(developpeur.Nom) },
                { "@idprofil", developpeur.Idprofil }
            };
            ConnexionBdd conn = ConnexionBdd.GetInstance(connectionString);
            conn.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Ajoute un profil
        /// </summary>
        /// <param name="profil"></param>
        public static void AddProfil(Profil profil)
        {
            string req = "insert into profil(nom) values (@nom);";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@nom", profil.Nom }
            };
            ConnexionBdd conn = ConnexionBdd.GetInstance(connectionString);
            conn.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Modification d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public static void UpdateDeveloppeur(Developpeur developpeur)
        {
            string req = "update developpeur set nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idprofil = @idprofil ";
            req += "where iddeveloppeur = @iddeveloppeur;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idDeveloppeur", developpeur.Iddeveloppeur },
                { "@nom", developpeur.Nom },
                { "@prenom", developpeur.Prenom },
                { "@tel", developpeur.Tel },
                { "@mail", developpeur.Mail },
                { "idprofil", developpeur.Idprofil }
            };
            ConnexionBdd conn = ConnexionBdd.GetInstance(connectionString);
            conn.ReqUpdate(req, parameters);
        }

        /// <summary>
        /// Demande de modification du pwd
        /// </summary>
        /// <param name="developpeur"></param>
        public static void UpdatePwd(Developpeur developpeur)
        {
            string req = "update developpeur set pwd = @pwd ";
            req += "where iddeveloppeur = @iddeveloppeur;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@idDeveloppeur", developpeur.Iddeveloppeur },
                { "@pwd", GetStringSha256Hash(developpeur.Pwd) }
            };
            ConnexionBdd conn = ConnexionBdd.GetInstance(connectionString);
            conn.ReqUpdate(req, parameters);
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
