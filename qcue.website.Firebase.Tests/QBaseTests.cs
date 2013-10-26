using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QCue.Web.Models;

namespace QCue.Web.Firebase.Tests
{
    public class QBaseTests
    {
        [TestMethod]
        public void Returns_All_Queues()
        {
            // Arrange.
            QBase qbase = new QBase("https://qcue-live.firebaseio.com");

            // Act.
            List<Q> queues = qbase.GetAllQueues();

            // Assert.
            Assert.IsNotNull(queues);
        }
    }
}
