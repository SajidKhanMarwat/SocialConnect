using SocialConnect.Web.CustomMiddlewares._404NotFound;

namespace SocialConnect.Web.CustomMiddlewares
{
    public static class MiddlewareExtensions
    {
        // Extension method used to add the middleware to the HTTP request pipeline.
        public static IApplicationBuilder UseCustomMiddlewareExtension(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotFoundMiddleware>();
        }
    }
}
