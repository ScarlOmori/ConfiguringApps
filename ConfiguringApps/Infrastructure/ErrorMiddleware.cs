using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ErrorMiddleware
    {
        private RequestDelegate nextRequest;

        public ErrorMiddleware(RequestDelegate request)
        {
            nextRequest = request;
        }

        public async Task Invoke(HttpContext context) 
        {
            await nextRequest.Invoke(context);

            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("Edge not supported", Encoding.UTF8);
            }
            else if (context.Response.StatusCode == 404) 
            {
                await context.Response.WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }
}
