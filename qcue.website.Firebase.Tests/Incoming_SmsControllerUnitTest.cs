using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QCue.Web.Controllers;
using QCue.Web.Models;

namespace qcue.website.Firebase.Tests
{
    [TestClass]
    public class Incoming_SmsControllerUnitTest
    {
        [TestMethod]
        public void Receives_Sms_And_Adds_User_To_Queue()
        {
            var controller = new Incoming_SmsController();

            var incomingSmsMessage = new IncomingSmsMessage
            {
                From = "4477123456789",
                To = "447860033153",
                Msg_Id = Convert.ToString(Guid.NewGuid()),
                Content = "HELI"
            };

            controller.Get(incomingSmsMessage);
        }
    }
}
