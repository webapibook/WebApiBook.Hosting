using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebHost.Controllers
{
    public class ResourceController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var ms = new MemoryStream();
            var tw = new StreamWriter(ms);
            tw.Write("Chunked transfer encoding");
            tw.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            var res = new HttpResponseMessage
            {
                //Content = new StringContent("Chunked transfer encoding")
                Content = new PushStreamContent((s, cont, ctx) =>
                {
                    using (var wr = new StreamWriter(s))
                    {
                        wr.Write("19\r\nChunked transfer encoding\r\n0");
                    }
                })
            };
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            res.Headers.TransferEncodingChunked = true;
            res.Content.Headers.ContentLength = null;
            return res;
        }
    }
}
