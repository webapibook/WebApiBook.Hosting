using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHost.Controllers
{
    public class MvcController : Controller
    {
        //
        // GET: /Mvc/

        public string Index()
        {
            Response.Headers.Add("Transfer-Encoding", "chunked");
            Response.BufferOutput = false;
            Response.Output.Write("transfer encoding");
            Response.Output.Flush();
            Response.End();
            return "abc";
        }

    }
}
