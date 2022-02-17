using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Habilitations.controleur;
using Habilitations.modele;

namespace Habilitations.vue
{
    /// <summary>
    /// Fenêtre d'affichage des développeurs et de leurs profils
    /// </summary>
    public partial class FrmHabilitations : Form
    {
        /// <summary>
        /// instance du controleur
        /// </summary>
        private readonly Controle controle;
        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private Boolean enCoursDeModif = false;

        /// <summary>
        /// Objet pour gérer la liste des développeurs
        /// </summary>
        readonly BindingSource bdgDeveloppeurs = new BindingSource();

        /// <summary>
        /// Objet pour gérer la liste des profils
        /// </summary>
        readonly BindingSource bdgProfils = new BindingSource();

        /// <summary>
        /// Initialisation des composants graphiques
        /// Récupération du controleur
        /// </summary>
        /// <param name="controle"></param>
        public FrmHabilitations(Controle controle)
        {
            InitializeComponent();
            this.controle = controle;
            Init();
        }

        /// <summary>
        /// Initialisation de la frame : remplissage des listes
        /// </summary>
        private void Init()
        {
            RemplirListeDeveloppeurs();
            RemplirListeProfils();
            grbPwd.Enabled = false;
        }

        /// <summary>
        /// Affiche les développeurs
        /// </summary>
        private void RemplirListeDeveloppeurs()
        {
            List<Developpeur> lesDeveloppeurs = controle.GetLesDeveloppeurs();       
            bdgDeveloppeurs.DataSource = lesDeveloppeurs;
            dgvDeveloppeurs.DataSource = bdgDeveloppeurs;
            dgvDeveloppeurs.Columns["iddeveloppeur"].Visible = false;
            dgvDeveloppeurs.Columns["idprofil"].Visible = false;
            dgvDeveloppeurs.Columns["pwd"].Visible = false;
            dgvDeveloppeurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Affiche les profils
        /// </summary>
        private void RemplirListeProfils()
        {
            List<Profil> lesProfils = controle.GetLesProfils();
            bdgProfils.DataSource = lesProfils;
            cboProfil.DataSource = bdgProfils;
            if (cboProfil.Items.Count > 0)
            {
                cboProfil.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupprimer_Click(object sender, System.EventArgs e)
        {
            if (dgvDeveloppeurs.SelectedRows.Count > 0)
            {
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                if (developpeur.Profil != "admin")
                {
                    if (MessageBox.Show("Voulez-vous vraiment supprimer " + developpeur.Nom + " " + developpeur.Prenom + " ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        controle.DelDeveloppeur(developpeur);
                        RemplirListeDeveloppeurs();
                    }
                    else
                    {
                        MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Un developpeur avec profil 'admin' ne peut être supprimé", "Information");
                }
 
            }
     
        }

        /// <summary>
        /// Vide les zones de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ViderDeveloppeur();
                grbLesDeveloppeurs.Enabled = true;
                enCoursDeModif = false;
                grbDeveloppeur.Text = "ajouter un développeur";
            }
        }

        /// <summary>
        /// Vider les zones de saisie d'un développeur
        /// </summary>
        private void ViderDeveloppeur()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtTel.Text = "";
            txtMail.Text = "";
            cboProfil.Enabled = true;
            cboProfil.SelectedIndex = 0;
        }

        /// <summary>
        /// Vider la zone de saisie d'un nouveau profil
        /// </summary>
        private void ViderProfil()
        {
            txtProfil.Text = "";
            cboProfil.SelectedIndex = 0;
        }

        /// <summary>
        /// Demande d'ajout ou de modification d'un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnregDeveloppeur_Click(object sender, EventArgs e)
        {
            if(!txtNom.Text.Equals("") && !txtPrenom.Text.Equals("") && !txtTel.Text.Equals("") && !txtMail.Text.Equals("") && cboProfil.SelectedIndex != -1)
            {
                Profil profil = (Profil)bdgProfils.List[bdgProfils.Position];
                int iddeveloppeur = 0;
                if (enCoursDeModif)
                {
                    iddeveloppeur = (int)dgvDeveloppeurs.SelectedRows[0].Cells["iddeveloppeur"].Value;
                }
                Developpeur developpeur = new Developpeur(iddeveloppeur, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, profil.Idprofil, profil.Nom);
                if (enCoursDeModif)
                {
                    controle.UpdateDeveloppeur(developpeur);
                    enCoursDeModif = false;
                    grbLesDeveloppeurs.Enabled = true;
                    grbDeveloppeur.Text = "ajouter un développeur";

                }
                else
                {
                    controle.AddDeveloppeur(developpeur);
                }
                RemplirListeDeveloppeurs();
                ViderDeveloppeur();
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
        }

        /// <summary>
        ///  Demande de modification d'un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModifier_Click(object sender, EventArgs e)
        {
            if (dgvDeveloppeurs.SelectedRows.Count > 0)
            {
                enCoursDeModif = true;
                grbLesDeveloppeurs.Enabled = false;
                grbDeveloppeur.Text = "modifier un développeur";
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                txtNom.Text = developpeur.Nom;
                txtPrenom.Text = developpeur.Prenom;
                txtTel.Text = developpeur.Tel;
                txtMail.Text = developpeur.Mail;
                cboProfil.SelectedIndex = cboProfil.FindStringExact(developpeur.Profil);
                if (developpeur.Profil == "admin")
                {
                    cboProfil.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        /// <summary>
        /// Demande de changement du pwd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangPwd_Click(object sender, EventArgs e)
        {
            if (dgvDeveloppeurs.SelectedRows.Count > 0)
            {
                grbLesDeveloppeurs.Enabled = false;
                grbDeveloppeur.Enabled = false;
                grbPwd.Enabled = true;
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        /// <summary>
        /// Demande d'enregistrement du nouveau pwd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnregPwd_Click(object sender, EventArgs e)
        {
            if(!txtPwd1.Text.Equals("") && !txtPwd2.Text.Equals("") && txtPwd1.Text.Equals(txtPwd2.Text))
            {
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                developpeur.Pwd = txtPwd1.Text;
                controle.UpdatePwd(developpeur);
                ViderPwd();
            }
            else
            {
                MessageBox.Show("Les 2 zones doivent être remplies et de contenu identique", "Information");
            }
        }

        /// <summary>
        /// Annulation de demande d'enregistrement d'un nouveau pwd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnnulerPwd_Click(object sender, EventArgs e)
        {
            ViderPwd();
        }

        /// <summary>
        /// Vider la zone du pwd et empêche la saisie
        /// </summary>
        private void ViderPwd()
        {
            txtPwd1.Text = "";
            txtPwd2.Text = "";
            grbLesDeveloppeurs.Enabled = true;
            grbDeveloppeur.Enabled = true;
            grbPwd.Enabled = false;
        }

        /// <summary>
        /// Supprimer un profil, après avoir vérifié si le profil n'est pas attribué à un des développeurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuppProfil_Click(object sender, EventArgs e)
        {
            List<Developpeur> lesDeveloppeurs = controle.GetLesDeveloppeurs();
            Profil profil = (Profil)bdgProfils.List[bdgProfils.Position];
            if (lesDeveloppeurs.Exists(developpeur => developpeur.Idprofil.Equals(profil.Idprofil)) || profil.Nom == "admin")
            {
                MessageBox.Show("Ce profil est utilisé et ne peut être supprimé.", "Information");
            }
            else
            {
                controle.DelProfil(profil);
            }            
            RemplirListeProfils();
            ViderProfil();
            
        }

        /// <summary>
        /// Ajouter un profil, après avoir vérifié qu'un nom a été saisi et que le profil n'existe pas déjà
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjoutProfil_Click(object sender, EventArgs e)
        {
            if (txtProfil.Text != "")
            {
                string nouveauProfil = txtProfil.Text.ToLower();
                List<Profil> lesProfils = controle.GetLesProfils();
                if (lesProfils.Exists(unProfil => unProfil.Nom.Equals(nouveauProfil)))
                {
                    MessageBox.Show("Ce profil existe déjà.", "Information");
                } 
                else
                {
                    Profil profil = new Profil(0, nouveauProfil);
                    controle.AddProfil(profil);
                }
            }
            RemplirListeProfils();
            ViderProfil();            
        }
    } 
}
