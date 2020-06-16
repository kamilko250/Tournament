using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Tournament.Models;




namespace TournamentTest
{
    [TestClass]
    public class RefereelistTest
    {
        [TestMethod]
        public void Add_Referee_Test()
        {
            //arrange
            string name = "TestName";
            string surname = "TestSurname";
            int id = 98;

            //act
            Referee testReferee = new Referee() { Name = name, Surname = surname, ID = id };
            RefereeList testrefereeList = new RefereeList();
            testrefereeList.Add(testReferee);



            //assert
            Referee lookingReferee = testrefereeList.FindByID(id);

            Assert.AreEqual(name, lookingReferee.Name, "Incompatibility in Add Referee to List");
            Assert.AreEqual(surname, lookingReferee.Surname, "Incompatibility in Add Referee to List");
            Assert.AreEqual(id, lookingReferee.ID, "Incompatibility in Add Referee to List");
        }

        public void Remove_Referee_Test()
        {
            //arrange
            string name = "TestName";
            string surname = "Testsurname";
            int id = 98;

            //act
            Referee testReferee = new Referee() { Name = name, Surname = surname, ID = id };
            RefereeList testRefereeList = new RefereeList();
            testRefereeList.Add(testReferee);
            testRefereeList.Remove(id);



            //assert
            var check = testRefereeList.FindByID(id);

            Assert.AreEqual(null, check, "Incompatibility in Remove Player from list");
        }
    }
}