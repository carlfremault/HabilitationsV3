using Habilitations.controleur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Habilitations.vue
{
    /// <summary>
    /// Fenêtre d'authentification (seuls les admin peuvent accéder à l'application)
    /// </summary>
    public partial class FrmAuthentification : Form
    {
        /// <summary>
        /// instance du controleur
        /// </summary>
        private readonly Controle controle;

        public FrmAuthentification(Controle controle)
        {
            InitializeComponent();
            this.controle = controle;
        }

        /// <summary>
        /// Demande au controleur de controler l'authentification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (!txtNom.Text.Equals("") && !txtPrenom.Text.Equals("") && !txtPwd.Text.Equals(""))
            {
                if (!controle.ControleAuthentification(txtNom.Text, txtPrenom.Text, txtPwd.Text))
                {
                    MessageBox.Show("Authentification incorrecte ou vous n'êtes pas admin", "Alerte");
                    txtNom.Text = "";
                    txtPrenom.Text = "";
                    txtPwd.Text = "";
                    txtNom.Focus();
                }
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
        }
    }
}
