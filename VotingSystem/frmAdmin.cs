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
    public partial class frmAdmin : Form
    {
        public Vote vote { get; set; }
        public Administrator administrator { get; set; }
        public frmAdmin(Vote curentVote, Administrator admin)
        {
            InitializeComponent();
            RefreshOptionsList();
            vote = curentVote;
            lblVoteName.Text = vote.name;
            administrator = admin;
        }

        private void btnAddOption_Click(object sender, EventArgs e)
        {
            administrator.AddVoteOption(vote, new VoteOption(editNewOption.Text, editNewOptionDescription.Text));
            RefreshOptionsList();
        }

        private void RefreshOptionsList()
        {
            listVoteOptions.Items.Clear();
            foreach(var voteOption in Database.GetVoteOptions())
            {
                listVoteOptions.Items.Add(voteOption.name);
            }
        }
    }
}
