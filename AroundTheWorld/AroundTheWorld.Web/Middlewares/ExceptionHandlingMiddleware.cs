using AroundTheWorld.Web.Exceptions;
using Newtonsoft.Json;

namespace AroundTheWorld.Web.Middlewares
{
    public class ExceptionHandlingMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = StatusCodes.Status500InternalServerError;

            switch (exception)
            {

            }

            var errorResponse = new ExceptionResponseModel
            {
                status = statusCode.ToString(),
                message = exception.Message
            };

            var errorResponseJson = JsonConvert.SerializeObject(errorResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorResponseJson);
        }
    }
}
