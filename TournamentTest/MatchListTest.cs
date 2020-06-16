using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Tournament.Models;




namespace TournamentTest
{
    [TestClass]
    public class MatchListTest
    {
        [TestMethod]
        public void Add_Match_Test()
        {
            //arrange
            string name = "TestName";
            int scoreA = 6;
            int scoreB = 9;
            int id = 98;

            //act
            Match testMatch = new Match() { Name = name, ID = id, TeamAScore = scoreA, TeamBScore = scoreB };

            MatchList testmatchList = new MatchList();
            testmatchList.Add(testMatch);



            //assert
            Match lookingMatch = testmatchList.FindByID(id);

            Assert.AreEqual(name, lookingMatch.Name, "Incompatibility in Add Match to List");
            Assert.AreEqual(id, lookingMatch.ID, "Incompatibility in Add Match to List");
            Assert.AreEqual(scoreA, lookingMatch.TeamAScore, "Incompatibility in Add Match to List");
            Assert.AreEqual(scoreB, lookingMatch.TeamBScore, "Incompatibility in Add Match to List");
        }

        public void Remove_Team_Test()
        {
            // arrange
            string name = "TestName";
            int scoreA = 6;
            int scoreB = 9;
            int id = 98;

            //act
            Match testMatch = new Match() { Name = name, ID = id, TeamAScore = scoreA, TeamBScore = scoreB };

            MatchList testmatchList = new MatchList();
            testmatchList.Add(testMatch);
            testmatchList.Remove(id);


            //assert
            Match lookingMatch = testmatchList.FindByID(id);


            Assert.AreEqual(null, lookingMatch, "Incompatibility in Remove Match from list");
        }
    }
}