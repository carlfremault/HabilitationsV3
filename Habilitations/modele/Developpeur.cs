
namespace Habilitations.modele
{
    public class Developpeur
    {
        private readonly int iddeveloppeur;
        private readonly string nom;
        private readonly string prenom;
        private readonly string tel;
        private readonly string mail;
        private readonly int idprofil;
        private readonly string profil;

        public int Iddeveloppeur { get => iddeveloppeur; }
        public string Nom { get => nom; }
        public string Prenom { get => prenom; }
        public string Tel { get => tel; }
        public string Mail { get => mail; }
        public int Idprofil { get => idprofil; }
        public string Profil { get => profil; }
        public string Pwd { get; set; }

        /// <summary>
        /// Constructeur : valorise les propriétés
        /// </summary>
        /// <param name="iddeveloppeur"></param>
        /// <param name="nom"></param>
        /// <param name="prenon"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        /// <param name="idprofil"></param>
        /// <param name="profil"></param>
        public Developpeur(int iddeveloppeur, string nom, string prenom, string tel, string mail, int idprofil, string profil)
        {
            this.iddeveloppeur = iddeveloppeur;
            this.nom = nom;
            this.prenom = prenom;
            this.tel = tel;
            this.mail = mail;
            this.idprofil = idprofil;
            this.profil = profil;
        }

    }
}
