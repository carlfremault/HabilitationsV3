namespace Habilitations.vue
{
    partial class FrmHabilitations
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDeveloppeurs = new System.Windows.Forms.DataGridView();
            this.grbLesDeveloppeurs = new System.Windows.Forms.GroupBox();
            this.btnChangPwd = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.grbDeveloppeur = new System.Windows.Forms.GroupBox();
            this.btnAnnulerDeveloppeur = new System.Windows.Forms.Button();
            this.btnEnregDeveloppeur = new System.Windows.Forms.Button();
            this.cboProfil = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.grbPwd = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAnnulerPwd = new System.Windows.Forms.Button();
            this.btnEnregPwd = new System.Windows.Forms.Button();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.txtPwd1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeveloppeurs)).BeginInit();
            this.grbLesDeveloppeurs.SuspendLayout();
            this.grbDeveloppeur.SuspendLayout();
            this.grbPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDeveloppeurs
            // 
            this.dgvDeveloppeurs.AllowUserToAddRows = false;
            this.dgvDeveloppeurs.AllowUserToDeleteRows = false;
            this.dgvDeveloppeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeveloppeurs.Location = new System.Drawing.Point(6, 19);
            this.dgvDeveloppeurs.MultiSelect = false;
            this.dgvDeveloppeurs.Name = "dgvDeveloppeurs";
            this.dgvDeveloppeurs.ReadOnly = true;
            this.dgvDeveloppeurs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDeveloppeurs.Size = new System.Drawing.Size(581, 206);
            this.dgvDeveloppeurs.TabIndex = 0;
            // 
            // grbLesDeveloppeurs
            // 
            this.grbLesDeveloppeurs.Controls.Add(this.btnChangPwd);
            this.grbLesDeveloppeurs.Controls.Add(this.btnSupprimer);
            this.grbLesDeveloppeurs.Controls.Add(this.btnModifier);
            this.grbLesDeveloppeurs.Controls.Add(this.dgvDeveloppeurs);
            this.grbLesDeveloppeurs.Location = new System.Drawing.Point(12, 12);
            this.grbLesDeveloppeurs.Name = "grbLesDeveloppeurs";
            this.grbLesDeveloppeurs.Size = new System.Drawing.Size(605, 264);
            this.grbLesDeveloppeurs.TabIndex = 1;
            this.grbLesDeveloppeurs.TabStop = false;
            this.grbLesDeveloppeurs.Text = "les développeurs";
            // 
            // btnChangPwd
            // 
            this.btnChangPwd.Location = new System.Drawing.Point(168, 231);
            this.btnChangPwd.Name = "btnChangPwd";
            this.btnChangPwd.Size = new System.Drawing.Size(85, 23);
            this.btnChangPwd.TabIndex = 3;
            this.btnChangPwd.Text = "changer pwd";
            this.btnChangPwd.UseVisualStyleBackColor = true;
            this.btnChangPwd.Click += new System.EventHandler(this.BtnChangPwd_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(87, 231);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(75, 23);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(6, 231);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.BtnModifier_Click);
            // 
            // grbDeveloppeur
            // 
            this.grbDeveloppeur.Controls.Add(this.btnAnnulerDeveloppeur);
            this.grbDeveloppeur.Controls.Add(this.btnEnregDeveloppeur);
            this.grbDeveloppeur.Controls.Add(this.cboProfil);
            this.grbDeveloppeur.Controls.Add(this.label5);
            this.grbDeveloppeur.Controls.Add(this.label4);
            this.grbDeveloppeur.Controls.Add(this.label3);
            this.grbDeveloppeur.Controls.Add(this.label2);
            this.grbDeveloppeur.Controls.Add(this.txtMail);
            this.grbDeveloppeur.Controls.Add(this.txtTel);
            this.grbDeveloppeur.Controls.Add(this.txtPrenom);
            this.grbDeveloppeur.Controls.Add(this.label1);
            this.grbDeveloppeur.Controls.Add(this.txtNom);
            this.grbDeveloppeur.Location = new System.Drawing.Point(12, 282);
            this.grbDeveloppeur.Name = "grbDeveloppeur";
            this.grbDeveloppeur.Size = new System.Drawing.Size(605, 129);
            this.grbDeveloppeur.TabIndex = 2;
            this.grbDeveloppeur.TabStop = false;
            this.grbDeveloppeur.Text = "ajouter un développeur";
            // 
            // btnAnnulerDeveloppeur
            // 
            this.btnAnnulerDeveloppeur.Location = new System.Drawing.Point(87, 98);
            this.btnAnnulerDeveloppeur.Name = "btnAnnulerDeveloppeur";
            this.btnAnnulerDeveloppeur.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulerDeveloppeur.TabIndex = 10;
            this.btnAnnulerDeveloppeur.Text = "annuler";
            this.btnAnnulerDeveloppeur.UseVisualStyleBackColor = true;
            this.btnAnnulerDeveloppeur.Click += new System.EventHandler(this.BtnAnnuler_Click);
            // 
            // btnEnregDeveloppeur
            // 
            this.btnEnregDeveloppeur.Location = new System.Drawing.Point(6, 98);
            this.btnEnregDeveloppeur.Name = "btnEnregDeveloppeur";
            this.btnEnregDeveloppeur.Size = new System.Drawing.Size(75, 23);
            this.btnEnregDeveloppeur.TabIndex = 9;
            this.btnEnregDeveloppeur.Text = "enregistrer";
            this.btnEnregDeveloppeur.UseVisualStyleBackColor = true;
            this.btnEnregDeveloppeur.Click += new System.EventHandler(this.BtnEnregDeveloppeur_Click);
            // 
            // cboProfil
            // 
            this.cboProfil.FormattingEnabled = true;
            this.cboProfil.Location = new System.Drawing.Point(354, 71);
            this.cboProfil.Name = "cboProfil";
            this.cboProfil.Size = new System.Drawing.Size(161, 21);
            this.cboProfil.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "profil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "tel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "prenom";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(354, 19);
            this.txtMail.MaxLength = 50;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(245, 20);
            this.txtMail.TabIndex = 6;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(354, 45);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(161, 20);
            this.txtTel.TabIndex = 7;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(54, 45);
            this.txtPrenom.MaxLength = 20;
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(245, 20);
            this.txtPrenom.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "nom";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(54, 19);
            this.txtNom.MaxLength = 20;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(245, 20);
            this.txtNom.TabIndex = 3;
            // 
            // grbPwd
            // 
            this.grbPwd.Controls.Add(this.label7);
            this.grbPwd.Controls.Add(this.btnAnnulerPwd);
            this.grbPwd.Controls.Add(this.btnEnregPwd);
            this.grbPwd.Controls.Add(this.txtPwd2);
            this.grbPwd.Controls.Add(this.txtPwd1);
            this.grbPwd.Controls.Add(this.label6);
            this.grbPwd.Location = new System.Drawing.Point(12, 417);
            this.grbPwd.Name = "grbPwd";
            this.grbPwd.Size = new System.Drawing.Size(605, 77);
            this.grbPwd.TabIndex = 3;
            this.grbPwd.TabStop = false;
            this.grbPwd.Text = "changer le mot de passe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "encore";
            // 
            // btnAnnulerPwd
            // 
            this.btnAnnulerPwd.Location = new System.Drawing.Point(87, 45);
            this.btnAnnulerPwd.Name = "btnAnnulerPwd";
            this.btnAnnulerPwd.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulerPwd.TabIndex = 4;
            this.btnAnnulerPwd.Text = "annuler";
            this.btnAnnulerPwd.UseVisualStyleBackColor = true;
            this.btnAnnulerPwd.Click += new System.EventHandler(this.BtnAnnulerPwd_Click);
            // 
            // btnEnregPwd
            // 
            this.btnEnregPwd.Location = new System.Drawing.Point(6, 45);
            this.btnEnregPwd.Name = "btnEnregPwd";
            this.btnEnregPwd.Size = new System.Drawing.Size(75, 23);
            this.btnEnregPwd.TabIndex = 3;
            this.btnEnregPwd.Text = "Enregistrer";
            this.btnEnregPwd.UseVisualStyleBackColor = true;
            this.btnEnregPwd.Click += new System.EventHandler(this.BtnEnregPwd_Click);
            // 
            // txtPwd2
            // 
            this.txtPwd2.Location = new System.Drawing.Point(354, 19);
            this.txtPwd2.MaxLength = 50;
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.PasswordChar = '*';
            this.txtPwd2.Size = new System.Drawing.Size(245, 20);
            this.txtPwd2.TabIndex = 2;
            // 
            // txtPwd1
            // 
            this.txtPwd1.Location = new System.Drawing.Point(54, 19);
            this.txtPwd1.MaxLength = 50;
            this.txtPwd1.Name = "txtPwd1";
            this.txtPwd1.PasswordChar = '*';
            this.txtPwd1.Size = new System.Drawing.Size(245, 20);
            this.txtPwd1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "pwd";
            // 
            // FrmHabilitations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 502);
            this.Controls.Add(this.grbPwd);
            this.Controls.Add(this.grbDeveloppeur);
            this.Controls.Add(this.grbLesDeveloppeurs);
            this.Name = "FrmHabilitations";
            this.Text = "Habilitations";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeveloppeurs)).EndInit();
            this.grbLesDeveloppeurs.ResumeLayout(false);
            this.grbDeveloppeur.ResumeLayout(false);
            this.grbDeveloppeur.PerformLayout();
            this.grbPwd.ResumeLayout(false);
            this.grbPwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeveloppeurs;
        private System.Windows.Forms.GroupBox grbLesDeveloppeurs;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.GroupBox grbDeveloppeur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Button btnEnregDeveloppeur;
        private System.Windows.Forms.ComboBox cboProfil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAnnulerDeveloppeur;
        private System.Windows.Forms.GroupBox grbPwd;
        private System.Windows.Forms.TextBox txtPwd2;
        private System.Windows.Forms.TextBox txtPwd1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAnnulerPwd;
        private System.Windows.Forms.Button btnEnregPwd;
        private System.Windows.Forms.Button btnChangPwd;
        private System.Windows.Forms.Label label7;
    }
}

