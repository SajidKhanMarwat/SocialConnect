using SocialConnect.Web.CustomMiddlewares._404NotFound;
using SocialConnect.Web.CustomMiddlewares.GlobalException;

namespace SocialConnect.Web.CustomMiddlewares
{
    public static class MiddlewareExtensions
    {
        // Extension method used to add the middleware to the HTTP request pipeline.
        public static IApplicationBuilder UseCustomMiddlewareExtension(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<NotFoundMiddleware>();
            builder.UseMiddleware<GlobalExceptionHandler>();
            return builder;
        }
    }
}
