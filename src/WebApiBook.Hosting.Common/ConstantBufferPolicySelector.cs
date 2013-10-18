using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Hosting;

namespace WebApiBook.Hosting.Common
{
    public class ConstantBufferPolicySelector : IHostBufferPolicySelector
    {
        private readonly bool _buffer;

        public ConstantBufferPolicySelector(bool buffer)
        {
            _buffer = buffer;
        }

        public bool UseBufferedInputStream(object hostContext)
        {
            return _buffer;
        }

        public bool UseBufferedOutputStream(HttpResponseMessage response)
        {
            var ctx = HttpContext.Current;
            return _buffer;
        }
    }
}
