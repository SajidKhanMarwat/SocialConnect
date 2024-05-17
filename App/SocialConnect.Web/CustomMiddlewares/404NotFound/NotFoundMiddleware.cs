namespace SocialConnect.Web.CustomMiddlewares._404NotFound
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;
        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 404)
            {
                // Customize the response for 404 error
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<h1>404 - Not Found</h1>");
            }
        }
    }
}
