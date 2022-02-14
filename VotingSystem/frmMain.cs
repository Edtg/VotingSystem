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
    public partial class frmMain : Form
    {
        private Vote vote { get; }
        private Voter voter { get; set; }
        private Administrator administrator { get; set; }
        private Auditor auditor { get; set; }
        public frmMain()
        {
            InitializeComponent();

            // Create an example vote
            vote = new Vote("UK General Election", "2022 general election", new DateTime(2022, 1, 22), 7);

            foreach(VoteOption voteOption in Database.GetVoteOptions())
            {
                vote.AddOption(voteOption);
            }

            cboVote.Items.Add(vote.name);
            cboVote.SelectedIndex = 0;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Open the login form
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() != DialogResult.OK) // If the login form is cancelled, close this form
            {
                Close();
            }

            try // Set logged in user as voter
            {
                voter = (Voter)frm.loggedInUser;
                btnSubmitVote.Enabled = true;
            }
            catch(Exception ex)
            { }

            try // Set logged in user as administrator
            {
                administrator = (Administrator)frm.loggedInUser;
                btnSubmitVote.Enabled = false;

                MenuStrip adminMenuStrip = new MenuStrip();
                adminMenuStrip.Items.Add("Admin");
                adminMenuStrip.Items[0].Text = "Admin Options";
                adminMenuStrip.Items[0].Click += AdminButtonClicked;
                this.Controls.Add(adminMenuStrip);
            }
            catch (Exception ex)
            { }

            try // Set logged in user as auditor
            {
                auditor = (Auditor)frm.loggedInUser;
                btnSubmitVote.Enabled = false;

                MenuStrip auditorMenuStrip = new MenuStrip();
                auditorMenuStrip.Items.Add("Auditor");
                auditorMenuStrip.Items[0].Text = "Auditor Options";
                auditorMenuStrip.Items[0].Click += AuditorButtonClicked;
                this.Controls.Add(auditorMenuStrip);
            }
            catch (Exception ex)
            { }
        }

        private void VoteButtonClicked(object sender, EventArgs e)
        {
            // Increment the selected option count
            if (!voter.hasVoted)
            {
                VoteOption option = vote.options[cboVoteOptions.SelectedIndex];
                voter.SubmitVote(option);
                MessageBox.Show("Vote submitted");
            }
            else
            {
                MessageBox.Show("You have already voted");
            }
        }

        private void cboVote_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the selected vote is changed, update the options
            cboVoteOptions.Items.Clear();
            foreach (VoteOption option in vote.options)
            {
                cboVoteOptions.Items.Add(option.name);
            }
            cboVoteOptions.SelectedIndex = 0;
        }

        private void AdminButtonClicked(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin(vote, administrator);
            frm.Show();
        }

        private void AuditorButtonClicked(object sender, EventArgs e)
        {
            frmAuditor frm = new frmAuditor(vote);
            frm.Show();
        }
    }
}
