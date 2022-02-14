using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class Voter : User
    {
        public int voterID { get; set; }
        public bool hasVoted { get; set; }

        public Voter(string name, string password) : base(name, password)
        { }

        public void SubmitVote(VoteOption voteOption)
        {
            voteOption.IncrementCount();
            hasVoted = true;
            Database.SetVoterVoted(this);
        }
    }
}
