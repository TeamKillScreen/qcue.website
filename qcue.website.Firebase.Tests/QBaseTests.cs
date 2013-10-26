using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QCue.Web.Models;

namespace QCue.Web.Firebase.Tests
{
    [TestClass]
    public class QBaseTests
    {
        [TestMethod]
        public void Returns_All_Queues()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            Dictionary<string, Q> queues = qbase.GetAllQueues();

            Assert.IsNotNull(queues);
            Assert.IsTrue(queues.Count > 0);
        }

        [TestMethod]
        public void Returns_Q_For_ShortCode()
        {
            string shortCode = "HELI";

            var qbase = new QBase("https://qcue-live.firebaseio.com");

            Q q = qbase.GetQueueByShortCode(shortCode);

            Assert.IsNotNull(q);
            Assert.IsTrue(!String.IsNullOrWhiteSpace(q.name));
            Assert.AreEqual(shortCode, q.shortCode);
        }

        [TestMethod]
        public void Return_All_Users()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            Dictionary<string, User> users = qbase.GetAllUsers();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public void Returns_User_For_MobileNumber()
        {
            string mobile = "4477123456789";
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            User user = qbase.GetUserByMobileNumber(mobile);

            Assert.IsNotNull(user);
            Assert.AreEqual(mobile, user.mobile);
        }

        [TestMethod]
        public void Adds_User_To_Queue()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            Q q = qbase.GetQueueByShortCode("HELI");
            User user = qbase.GetUserByMobileNumber("4477123456789");

            qbase.AddUserToQueue(q.queueId, new QUser
                {
                    userId = user.userId,
                    status = "waiting"
                });
        }
    }
}
