using System.Net;

namespace MiddlewareExample.Web.Middlewares
{
    public class WhiteIpAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDalegate;
        private const string WhiteIpAddress = "::1";
        public WhiteIpAddressControlMiddleware(RequestDelegate requestDalegate)
        {
            _requestDalegate = requestDalegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //IPV4 => 127.0.0.1  Localhost
            //IPV6 => ::1 => Localhost
            var reqIpAddress = context.Connection.RemoteIpAddress;
            bool AnyWhiteIpAddress=IPAddress.Parse(WhiteIpAddress).Equals(reqIpAddress);
            if (AnyWhiteIpAddress == true)
            {
                await _requestDalegate(context);
            }
            else
            {
                context.Response.StatusCode=HttpStatusCode.Forbidden.GetHashCode();
                await context.Response.WriteAsync("Forbidden");
            }


        }
    }
}
