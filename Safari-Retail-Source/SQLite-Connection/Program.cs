using SafariRetail.InventorySystem;
using SQLite_Connection;
using System;
using System.Windows.Forms;

namespace SafariRetail.Launcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Task 4 (M4/D4): Implements a gated entry for enhanced system security.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Initialize the Login Form as the primary security gate
            // This follows the Event-Driven paradigm (P3)
            using (LoginForm login = new LoginForm())
            {
                // 2. Show the login form as a modal dialog. 
                // The application stays here until LoginForm sets a DialogResult.
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // 3. Launch the main Dashboard only after successful ValidateUser()
                    // This maintains a robust application state (M4)
                    Application.Run(new Form1());
                }
                else
                {
                    // 4. Exit gracefully if the manager clicks 'Exit' or fails login
                    Application.Exit();
                }
            }
        }
    }
}