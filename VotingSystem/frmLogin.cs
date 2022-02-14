using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingSystem
{
    public partial class frmLogin : Form
    {
        public User loggedInUser { get; set; }
        public frmLogin()
        {
            InitializeComponent();

            // Add login options to the combobox
            cboLoginType.Items.Add("Voter");
            cboLoginType.Items.Add("Administrator");
            cboLoginType.Items.Add("Auditor");
            cboLoginType.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if the login is valid
            bool loginSucessful = false;
            switch(cboLoginType.SelectedIndex)
            {
                case 0:
                    Voter voter = Database.GetVoter(editUsername.Text);
                    if (voter != null && voter.Login(editPassword.Text))
                    {
                        loginSucessful = true;
                        loggedInUser = voter;
                    }
                    break;
                case 1:
                    Administrator admin = Database.GetAdmin(editUsername.Text);
                    if (admin != null && admin.Login(editPassword.Text))
                    {
                        loginSucessful = true;
                        loggedInUser = admin;
                    }
                    break;
                case 2:
                    Auditor auditor = Database.GetAuditor(editUsername.Text);
                    if (auditor != null && auditor.Login(editPassword.Text))
                    {
                        loginSucessful = true;
                        loggedInUser = auditor;
                    }
                    break;
            }

            if (loginSucessful)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Username and password do not match records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cboLoginType.SelectedIndex == 0)
            {
                Database.AddVoter(editUsername.Text, editPassword.Text);
            }
            else
            {
                MessageBox.Show("Cannot create a user of this type");
            }
        }
    }
}
