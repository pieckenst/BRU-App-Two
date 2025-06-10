using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Burdukov_kurs
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(loginForm.AuthenticatedUser));
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
