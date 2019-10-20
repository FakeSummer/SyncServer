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

        public SessionVerificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /*public Task InvokeAsync(HttpContext context)
        {
            var verSuccess = SessionManager.VerifySession(tokenID);
            if (verSuccess == true)
            {
                return _next(context);
            }

            else
            {
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
        } */
    }
}
