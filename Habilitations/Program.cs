using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Habilitations.controleur;

namespace Habilitations
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#pragma warning disable S1848 // Objects should not be created to be dropped immediately without being used
            new Controle();
#pragma warning restore S1848 // Objects should not be created to be dropped immediately without being used
        }
    }
}
