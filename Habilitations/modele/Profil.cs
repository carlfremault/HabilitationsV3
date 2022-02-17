
namespace Habilitations.modele
{
    public class Profil
    {
 
        private readonly int idprofil;
        private readonly string nom;

        /// <summary>
        /// Constructeur : valorise les propriétés
        /// </summary>
        /// <param name="idprofil"></param>
        /// <param name="nom"></param>
        public Profil(int idprofil, string nom)
        {
            this.idprofil = idprofil;
            this.nom = nom;
        }

        public int Idprofil { get => idprofil; }
        public string Nom { get => nom; }

        /// <summary>
        /// Définit l'information à afficher (juste le nom)
        /// </summary>
        /// <returns>nom du profil</returns>
        public override string ToString()
        {
            return this.nom;
        }

    }
}
