using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextRequest;

        public BrowserTypeMiddleware(RequestDelegate request)
        {
            nextRequest = request;
        }

        public async Task Invoke(HttpContext context) 
        {
            context.Items["EdgeBrowser"] = context.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains("edge"));
            await nextRequest.Invoke(context);
        }
    }
}
