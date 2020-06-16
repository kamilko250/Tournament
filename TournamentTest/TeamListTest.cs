using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Tournament.Models;




namespace TournamentTest
{
    [TestClass]
    public class TeamListTest
    {
        [TestMethod]
        public void Add_Team_Test()
        {
            //arrange
            string name = "TestName";
            int id = 98;

            //act
            Team testTeam = new Team() { Name = name, ID = id };
            TeamList testTeamList = new TeamList();
            testTeamList.Add(testTeam);



            //assert
            Team lookingTeam = testTeamList.FindByID(id);

            Assert.AreEqual(name, lookingTeam.Name, "Incompatibility in Add Team to List");
            Assert.AreEqual(id, lookingTeam.ID, "Incompatibility in Add Team to List");
        }

        public void Remove_Team_Test()
        {
            //arrange
            string name = "TestName";
            int id = 98;

            //act
            Team testTeam = new Team() { Name = name, ID = id };
            TeamList testTeamList = new TeamList();
            testTeamList.Add(testTeam);
            testTeamList.Remove(id);


            //assert
            Team lookingTeam = testTeamList.FindByID(id);

            Assert.AreEqual(null, lookingTeam, "Incompatibility in Remove Team from list");
        }
    }
}