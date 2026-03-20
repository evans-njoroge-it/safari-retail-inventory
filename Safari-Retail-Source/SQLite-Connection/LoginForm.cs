using System;
using System.Windows.Forms;

namespace SQLite_Connection
{
    public partial class LoginForm : Form
    {
        // Static variable used by Form1 for "Operator: Evans" header
        public static string LoggedInUser { get; private set; } = string.Empty;

        public LoginForm()
        {
            InitializeComponent();
            this.ActiveControl = txtUsername;
        }

        // REFINEMENT: Resets the form every time Evans logs back in after a logout
        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter an Operator Username.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            DatabaseHelper db = new DatabaseHelper();

            if (db.ValidateUser(txtUsername.Text, txtPassword.Text))
            {
                LoggedInUser = txtUsername.Text;

                MessageBox.Show($"Access Granted. Welcome back, {LoggedInUser}!",
                                "Safari Retail | System Access",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;

                // REFINEMENT: Hide instead of Close to allow the Logout loop to function
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials. Access Denied.", "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // REFINEMENT: Fully terminates the process when "Exit" is clicked
            Application.Exit();
        }
    }
}