using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QCue.Web.Controllers;
using QCue.Web.Models;
using System.Net.Http;
using System.Web.Http.ModelBinding;

namespace qcue.website.Firebase.Tests
{
    [TestClass]
    public class Incoming_SmsControllerUnitTest
    {
        [TestMethod]
        public void Receives_Sms_And_Adds_User_To_Queue()
        {
            // Arrange.
            var controller = new Incoming_SmsController();

            controller.Request = new HttpRequestMessage();
            controller.ModelState.Clear();

            var incomingSmsMessage = new IncomingSmsMessage
            {
                From = "4455523456789",
                To = "447860033153",
                Msg_Id = Convert.ToString(Guid.NewGuid()),
                Content = "HELI"
            };

            // Act.
            var response = controller.Get(incomingSmsMessage);

            // Assert.
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public void User_Full_Name_Is_Updated()
        {
            // Arrange.
            var controller = new Incoming_SmsController();

            controller.Request = new HttpRequestMessage();
            controller.ModelState.Clear();

            var incomingSmsMessage = new IncomingSmsMessage
            {
                From = "4455523456789",
                To = "447860033153",
                Msg_Id = Convert.ToString(Guid.NewGuid()),
                Content = "NAME Alice Bong"
            };

            // Act.
            var response = controller.Get(incomingSmsMessage);

            // Assert.
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}
