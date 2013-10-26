using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCue.Web.Models;
using QCue.Web.Firebase;

namespace QCue.Web.Controllers
{
    public class Incoming_SmsController : ApiController
    {
        // GET: http://www.qcue.me/api/incoming_sms?to=447860033153&from=441234567890&content=Hello+World&msg_id=AB_12345
        public HttpResponseMessage Get([FromUri]IncomingSmsMessage message)
        {
            /*
            if (this.ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }
            */

            var qbase = new QBase("https://qcue-live.firebaseio.com");

            var q = qbase.GetQueueByShortCode(message.Content);
            var user = qbase.GetUserByMobileNumber(message.From);

            qbase.AddUserToQueue(q.queueId, new QUser
            {
                userId = user.userId,
                status = "waiting"
            });

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
