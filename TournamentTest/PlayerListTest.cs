using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Tournament.Models;




namespace TournamentTest
{
    [TestClass]
    public class PlayerlistTest
    {
        [TestMethod]
        public void Add_Player_Test()
        {
            //arrange
            string name = "TestName";
            string surname = "Testsurname";
            int id = 98;

            //act
            Player testPlayer = new Player() { Name = name, Surname = surname, ID = id };
            PlayerList testplayerList = new PlayerList();
            testplayerList.Add(testPlayer);



            //assert
            Player lookingPlayer = testplayerList.FindByID(id);

            Assert.AreEqual(name, lookingPlayer.Name, "Incompatibility in Add Player to List");
            Assert.AreEqual(surname, lookingPlayer.Surname, "Incompatibility in Add Player to List");
            Assert.AreEqual(id, lookingPlayer.ID, "Incompatibility in Add Player to List");
        }

        public void Remove_Player_Test()
        {
            //arrange
            string name = "TestName";
            string surname = "Testsurname";
            int id = 98;

            //act
            Player testPlayer = new Player() { Name = name, Surname = surname, ID = id };
            PlayerList testplayerList = new PlayerList();
            testplayerList.Add(testPlayer);
            testplayerList.Remove(id);



            //assert
            var check = testplayerList.FindByID(id);


            Assert.AreEqual(null, check, "Incompatibility in Remove Player from list");
        }
    }
}
