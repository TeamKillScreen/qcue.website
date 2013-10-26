using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace qcue.website.Controllers
{
    public class Incoming_SmsController : ApiController
    {
        // GET: http://www.qcue.me/api/incoming_sms?to=447860033153&from=441234567890&content=Hello+World&msg_id=AB_12345
        public HttpResponseMessage Get(IncomingSmsMessage message)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}
