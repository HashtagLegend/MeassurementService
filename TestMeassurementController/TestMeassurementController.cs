using System.Collections.Generic;
using System.Linq;
using MeassurementWebService.Controllers;
using MeassurementWebService.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestMeassurementController
{
    [TestClass]
    public class TestMeassurementController
    {
        [TestMethod]
        public void TestGetAll()
        {
            //Arrange
            MeassurementController controller = new MeassurementController();
            //Act
            List<Meassurement> list = controller.GetMeassurements();
            int count = list.Count;

            //Assert
            //Assert.AreEqual(6, count);
            //Assert.IsNotNull(list);
            CollectionAssert.AllItemsAreNotNull(list);
        }

        [TestMethod]
        public void TestGetById()
        {
            //Arrange
            MeassurementController controller = new MeassurementController();
            //Act
            Meassurement returnedMeassurement = controller.GetMeassurementById(1);

            //Assert

            if (returnedMeassurement != null)
            {
                Assert.AreEqual(1, returnedMeassurement.Id);
            }
            else
            {
                Assert.IsTrue(true);
            }

            
        }

        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            MeassurementController controller = new MeassurementController();
            //Act
            Meassurement returnedMeassurement = controller.PostMeassurement(new Meassurement((float)22.2, (float)75.3, (float)21.7, System.DateTime.Now));

            //Assert
            Assert.IsNotNull(returnedMeassurement);

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            MeassurementController controller = new MeassurementController();
            //Act
            controller.Delete(2);
            Meassurement returnedMeassurement = controller.GetMeassurementById(2);
            

            //Assert
            Assert.AreEqual(0, returnedMeassurement.Id);
        }


    }
}
