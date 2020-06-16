using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament.Models;

namespace TournamentTest
{
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void Player_Constructor_Test()
        {
            //arrange
            string name = "TestName";
            int scoreA = 6;
            int scoreB = 9;
            int id = 98;

            //act
            Match testMatch = new Match() { Name = name, ID = id, TeamAScore = scoreA, TeamBScore = scoreB };

            //assert
            Assert.AreEqual(name, testMatch.Name, "Incompatibility in Match name");
            Assert.AreEqual(scoreA, testMatch.TeamAScore, "Incompatibility in Match id");
            Assert.AreEqual(scoreB, testMatch.TeamBScore, "Incompatibility in Match TeamAScore");
            Assert.AreEqual(id, testMatch.ID, "Incompatibility in Match TeamBScore");
        }
    }
}