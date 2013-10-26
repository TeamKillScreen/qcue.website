using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCue.Web.Models;
using QCue.Web.Firebase;
using System.Diagnostics;

namespace QCue.Web.Controllers
{
    public class Incoming_SmsController : ApiController
    {
        // GET: http://www.qcue.me/api/incoming_sms?to=447860033153&from=441234567890&content=Hello+World&msg_id=AB_12345
        public HttpResponseMessage Get([FromUri]IncomingSmsMessage message)
        {
            Trace.TraceInformation("Message: {0}", message);

            /*
            if (this.ModelState.IsValid)
            {
                Trace.TraceInformation("Message: {0}", message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, this.ModelState);
            }
            */

            var qbase = new QBase("https://qcue-live.firebaseio.com");

            var q = qbase.GetQueueByShortCode(message.Content);

            if (q == null)
            {
                string errorMessage = String.Format(
                    "No such queue: \"{0}\".", message.Content);

                var invalidQueueResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(errorMessage),
                    ReasonPhrase = errorMessage
                };

                throw new HttpResponseException(invalidQueueResponse);
            }

            var user = qbase.GetUserByMobileNumber(message.From);
            string status = null;

            if (user == null)
            {
                user = qbase.AddAnonymousUser(message.From);
                // TODO: status = "registering";
                status = "joined";
            }
            else
            {
                status = "joined";
            }

            qbase.AddUserToQueue(q.queueId, new QUser
            {
                userId = user.userId,
                status = status
            });

            var response = this.Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
