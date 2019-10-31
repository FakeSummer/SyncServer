using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncServer
{
    public class SessionVerificationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISessionManager _manager;

        public SessionVerificationMiddleware(RequestDelegate next, ISessionManager manager)
        {
            _next = next;
            _manager = manager;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/verify"))
            {
                return _next(context);
            }
            var tokenID = context.Request.Headers["Authorization"].SingleOrDefault().Split(" ")[1].Replace("\"","");
            var verSuccess =  _manager.VerifySession(new Guid (tokenID));
            if (verSuccess == true)
            {
                return _next(context);
            }
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        } 
    }
}
