using QCue.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCue.Web.Firebase
{
    public class QBase
    {
        private string p;

        public QBase(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public List<Q> GetAllQueues()
        {
            throw new NotImplementedException();
        }
    }
}