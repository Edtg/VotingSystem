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
    public partial class frmAuditor : Form
    {
        public Vote vote { get; set; }
        public List<VoteOption> voteOptions { get; set; }
        public frmAuditor(Vote currentVote)
        {
            InitializeComponent();
            vote = currentVote;
            cboVote.Items.Add(vote.name);
            cboVote.SelectedIndex = 0;
            voteOptions = Database.GetVoteOptions().ToList();
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            string results = $"Results for {vote.name}:\n";
            VoteOption highest = voteOptions.FirstOrDefault();
            foreach(VoteOption voteOption in voteOptions)
            {
                results += $"{voteOption.name}: {voteOption.count} votes\n";
                if (highest.count < voteOption.count)
                {
                    highest = voteOption;
                }
            }
            results += $"{highest.name} was the winner with {highest.count} votes";
            MessageBox.Show(results);
        }
    }
}
