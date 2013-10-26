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
        [Ignore]
        public void Returns_All_Queues()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            Dictionary<string, Q> queues = qbase.GetAllQueues();

            Assert.IsNotNull(queues);
            Assert.IsTrue(queues.Count > 0);
        }

        [TestMethod]
        [Ignore]
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
        [Ignore]
        public void Return_All_Users()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            Dictionary<string, User> users = qbase.GetAllUsers();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        [Ignore]
        public void Returns_User_For_MobileNumber()
        {
            string mobile = "4455523456789";
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            User user = qbase.GetUserByMobile(mobile);

            Assert.IsNotNull(user);
            Assert.AreEqual(mobile, user.mobile);
        }

        [TestMethod]
        [Ignore]
        public void Adds_User_To_Queue()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            Q q = qbase.GetQueueByShortCode("HELI");
            User user = qbase.GetUserByMobile("4455523456789");

            qbase.AddUserToQueue(q.queueId, new QUser
            {
                userId = user.userId,
                status = "waiting"
            });
        }

        [TestMethod]
        [Ignore]
        public void Adds_Sms_Task()
        {
            var smsTask = new SmsTask
            {
                smsTaskId = Convert.ToString(Guid.NewGuid()),
                task = "sms",
                payload = new SmsTaskPayload
                {
                    mobile = "4455523456789",
                    message = "Hello+World."                  
                }
            };

            var qbase = new QBase("https://qcue-live.firebaseio.com");

            qbase.AddTask(smsTask);
        }

        [TestMethod]
        [Ignore]
        public void Anonymous_User_Is_Added()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            var user = qbase.AddAnonymousUser("449999999999");

            Assert.IsNotNull(user);
            Assert.IsNotNull(user.userId);
            Assert.IsNotNull(user.fullName);
            Assert.IsNotNull(user.mobile);
        }

        [TestMethod]
        public void User_Is_Updated()
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            var user = new User
            {
                userId = "0e5d2d51-2bf7-4c1e-9d1a-952710f70725",
                fullName = "Alice Whyte",
                mobile = "4455523456789"
            };

            qbase.UpdateUser(user);
        }
    }
}
