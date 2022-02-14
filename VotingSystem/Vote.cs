using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class Vote
    {
        public string name { get; set; }
        public string description { get; set; }
        public List<VoteOption> options { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Vote(string voteName, string voteDescription, DateTime start, int numDays)
        {
            name = voteName;
            description = voteDescription;
            startDate = start;
            endDate = startDate.AddDays(numDays);
            options = new List<VoteOption>();
        }

        public void AddOption(VoteOption option)
        {
            options.Add(option);
        }
    }
}
