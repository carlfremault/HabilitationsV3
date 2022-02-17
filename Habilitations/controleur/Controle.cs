using System;
using System.Collections.Generic;
using Habilitations.dal;
using Habilitations.modele;
using Habilitations.vue;

namespace Habilitations.controleur
{
    /// <summary>
    /// Gère les interractions entre la vue et le modèle
    /// </summary>
    public class Controle
    {
        /// <summary>
        /// fenêtre d'authentification
        /// </summary>
        private readonly FrmAuthentification frmAuthentification;

        /// <summary>
        /// Ouverture de la fenêtre
        /// </summary>
        public Controle()
        {
            frmAuthentification = new FrmAuthentification(this);
            frmAuthentification.ShowDialog();
        }

        /// <summary>
        /// Demande la vérification de l'authentification
        /// Si correct, alors ouvre la fenêtre principale
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Boolean ControleAuthentification(string nom, string prenom, string pwd)
        {
            if (AccesDonnees.ControleAuthentification(nom, prenom, pwd))
            {
                frmAuthentification.Hide();
                (new FrmHabilitations(this)).ShowDialog();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Récupère et retourne les infos des développeurs provenant de la BDD
        /// </summary>
        /// <returns>liste des développeurs</returns>
        public List<Developpeur> GetLesDeveloppeurs()
        {
            return AccesDonnees.GetLesDeveloppeurs();
        }

        /// <summary>
        /// Récupère et retourne les infos des profils provenant de la BDD
        /// </summary>
        /// <returns>liste des profils</returns>
        public List<Profil> GetLesProfils()
        {
            return AccesDonnees.GetLesProfils();
        }

        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="developpeur">objet developpeur à supprimer</param>
        public void DelDeveloppeur(Developpeur developpeur)
        {
                AccesDonnees.DelDeveloppeur(developpeur);            
        }

        /// <summary>
        /// Demande de suppression d'un profil
        /// </summary>
        /// <param name="profil"></param>
        public void DelProfil(Profil profil)
        {
            AccesDonnees.DelProfil(profil);
        }

        /// <summary>
        /// Demande d'ajout d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void AddDeveloppeur(Developpeur developpeur)
        {
            AccesDonnees.AddDeveloppeur(developpeur);
        }

        /// <summary>
        /// Demande d'ajout d'un profil
        /// </summary>
        /// <param name="profil"></param>
        public void AddProfil(Profil profil)
        {
            AccesDonnees.AddProfil(profil);
        }

        /// <summary>
        /// Demande de modification d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void UpdateDeveloppeur(Developpeur developpeur)
        {
            AccesDonnees.UpdateDeveloppeur(developpeur);
        }

        /// <summary>
        /// Demande de changement de pwd
        /// </summary>
        /// <param name="developpeur"></param>
        public void UpdatePwd(Developpeur developpeur)
        {
            AccesDonnees.UpdatePwd(developpeur);
        }
    }
}
