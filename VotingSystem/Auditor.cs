using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class Auditor : User
    {
        public int AuditorID { get; set; }

        public Auditor(string name, string password) : base(name, password)
        { }
    }
}
