using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tournament.Models;

namespace TournamentTest
{
    [TestClass]
    public class RefereeTest
    {
        [TestMethod]
        public void Referee_Constructor_Test()
        {
            //arrange
            string name = "TestName";
            string surname = "Testsurname";
            int id = 98;

            //act
            Referee testReferee = new Referee() { Name = name, Surname = surname, ID = id };

            //assert
            Assert.AreEqual(name, testReferee.Name, "Incompatibility in Referee name");
            Assert.AreEqual(surname, testReferee.Surname, "Incompatibility in Referee surname");
            Assert.AreEqual(id, testReferee.ID, "Incompatibility in Referee id");
        }
    }
}
