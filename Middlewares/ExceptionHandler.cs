using Newtonsoft.Json;

namespace InventoryTrackApi.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Unhandled Exception: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                message = "An internal server error occurred. Please try again later.",

                // Optional: include details in development environment
                detail = exception.ToString() // remove in production if exposing exception details is not safe
            };

            var result = JsonConvert.SerializeObject(errorResponse);
            return context.Response.WriteAsync(result);
        }

    }
}
