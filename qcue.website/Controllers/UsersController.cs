using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCue.Web.Firebase;
using QCue.Web.Models;

namespace QCue.Web.Controllers
{
    public class UsersController : ApiController
    {
        public User Get(string id)
        {
            var qbase = new QBase("https://qcue-live.firebaseio.com");

            var user = qbase.GetUserByMobile(id);

            return user;
        }
    }
}
