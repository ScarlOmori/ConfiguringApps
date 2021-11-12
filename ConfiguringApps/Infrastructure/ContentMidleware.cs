using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ContentMidleware
    {
        private RequestDelegate nextDelegate;
        private UptimeService uptime;

        public ContentMidleware(RequestDelegate next, UptimeService upt)
        {
            nextDelegate = next;
            uptime = upt;
        }

        public async Task Invoke(HttpContext httpContext) 
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync($"This is from the context midleware (uptime:{uptime.Uptime}ms)", Encoding.UTF8);
            }
            else 
            {
                await nextDelegate.Invoke(httpContext);
            }
        }
    }
}
