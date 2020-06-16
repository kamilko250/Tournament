using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament.Models;

namespace TournamentTest
{
    [TestClass]
    public class TeamTeast
    {
        [TestMethod]
        public void Team_Constructor_Test()
        {
            //arrange
            string name = "TestName";
            int id = 98;

            //act
            Team testTeam = new Team() { Name = name, ID = id };

            //assert
            Assert.AreEqual(name, testTeam.Name, "Incompatibility in Team name");
            Assert.AreEqual(id, testTeam.ID, "Incompatibility in Team id");
        }
    }
}