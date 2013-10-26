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
        private const string NameTag = "NAME";

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
            var user = qbase.GetUserByMobileNumber(message.From);

            // this.EnsureUserIsKnown(message, user);

            if (this.IsUpdateUserMessage(message))
            {
                this.UpdateUser(message, qbase, user);
            }
            else
            {
                user = this.QueueUser(message, qbase, user);
            }

            var response = this.Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        private void EnsureUserIsKnown(IncomingSmsMessage message, Models.User user)
        {
            if (user == null)
            {
                string errorMessage = String.Format(
                    "No such user: \"{0}\".", message.From);

                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(errorMessage),
                    ReasonPhrase = errorMessage
                };

                Trace.TraceError(errorMessage);
                throw new HttpResponseException(response);
            }
        }

        private User QueueUser(IncomingSmsMessage message, QBase qbase, User user)
        {
            var q = qbase.GetQueueByShortCode(message.Content);

            this.EnsureQueueIsKnown(message, q);

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

            return user;
        }

        private void EnsureQueueIsKnown(IncomingSmsMessage message, Q q)
        {
            if (q == null)
            {
                string errorMessage = String.Format(
                    "No such queue: \"{0}\".", message.Content);

                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(errorMessage),
                    ReasonPhrase = errorMessage
                };

                Trace.TraceError(errorMessage);
                throw new HttpResponseException(response);
            }
        }

        private void UpdateUser(IncomingSmsMessage message, QBase qbase, User user)
        {
            string fullName = message.Content.Substring(NameTag.Length).Trim();

            user.fullName = fullName;

            qbase.UpdateUser(user);

            Trace.TraceInformation(
                "Updated user.fulName for \"{0}\" to \"{1}\"", user.userId, user.fullName);
        }

        private bool IsUpdateUserMessage(IncomingSmsMessage message)
        {
            return message.Content.ToUpper().StartsWith(NameTag);
        }
    }
}
