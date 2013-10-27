using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCue.Web.Controllers
{
    public class QController : Controller
    {
        //
        // GET: /QRedirect/
        [Route("q/{id}")]
        public ActionResult Get(string id)
        {
            return Redirect("/#/join-queue?shortCode=" + id);
        }
	}
}