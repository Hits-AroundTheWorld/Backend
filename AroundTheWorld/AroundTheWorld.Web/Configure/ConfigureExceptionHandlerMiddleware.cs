using AroundTheWorld.Web.Middlewares;

namespace AroundTheWorld.Web.Configure
{
    public static class ConfigureExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
