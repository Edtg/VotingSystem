using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;

namespace VotingSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VoterTestMethod()
        {
            Voter voter = new Voter("Voter1", "Password");
            Assert.AreEqual(voter.Login("Password"), true);
            Assert.AreNotEqual(voter.Login("pass"), true);
        }

        [TestMethod]
        public void AdminTestMethod()
        {
            Administrator admin = new Administrator("Voter1", "Password");
            Assert.AreEqual(admin.Login("Password"), true);
            Assert.AreNotEqual(admin.Login("pass"), true);
        }

        [TestMethod]
        public void AuditorTestMethod()
        {
            Auditor auditor = new Auditor("Voter1", "Password");
            Assert.AreEqual(auditor.Login("Password"), true);
            Assert.AreNotEqual(auditor.Login("pass"), true);
        }

        [TestMethod]
        public void SubmitVoteTestMethod()
        {
            Voter voter = new Voter("Voter1", "Password");
            VoteOption voteOption = new VoteOption("Submit Vote Option", "Option");
            Database.AddVoteOption(voteOption.name, voteOption.description);
            voter.SubmitVote(voteOption);
            Assert.AreEqual(voter.hasVoted, true);
            Assert.AreEqual(voteOption.count, 1);
        }

        [TestMethod]
        public void IncrementVoteTestMethod()
        {
            VoteOption voteOption = new VoteOption("Increment Vote Option", "Option");
            for (int i = 0; i < 10; i++)
            {
                voteOption.IncrementCount();
            }
            Assert.AreEqual(voteOption.count, 10);
        }
    }
}
