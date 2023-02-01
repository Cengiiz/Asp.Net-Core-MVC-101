namespace MiddlewareExample.Web.Middlewares
{
    public class WhiteIpAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDalegate;

        public WhiteIpAddressControlMiddleware(RequestDelegate requestDalegate)
        {
            _requestDalegate = requestDalegate;
        }

        public async Task InvokeAsync(HttpContent context)
        {
            //IPV4 => 127.0.0.1  Localhost
            //IPV6 => ::1 => Localhost




        }
    }
}
