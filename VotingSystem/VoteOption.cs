using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class VoteOption
    {
        public string name { get; set; }
        public string description { get; set; }
        public int count { get; set; }

        public VoteOption(string optionName, string optionDescription)
        {
            name = optionName;
            description = optionDescription;
        }

        public void IncrementCount()
        {
            count++;
            Database.UpdateVoteOptionCount(name, count);
        }
    }
}
