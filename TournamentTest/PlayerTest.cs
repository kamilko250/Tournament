using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament.Models;

namespace TournamentTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Player_Constructor_Test()
        {
            //arrange
            string name = "TestName";
            string surname = "Testsurname";
            int id = 98;

            //act
            Player testPlayer = new Player() { Name = name, Surname = surname, ID = id };

            //assert
            Assert.AreEqual(name, testPlayer.Name, "Incompatibility in Player name");
            Assert.AreEqual(surname, testPlayer.Surname, "Incompatibility in Player surname");
            Assert.AreEqual(id, testPlayer.ID, "Incompatibility in Player id");
        }
    }
}
