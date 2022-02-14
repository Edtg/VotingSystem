using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class Administrator : User
    {
        public int AdministratorID { get; set; }

        public Administrator(string name, string password) : base(name, password)
        { }

        public void AddVoteOption(Vote vote, VoteOption option)
        {
            vote.AddOption(option);
            Database.AddVoteOption(option.name, option.description);
        }
    }
}
