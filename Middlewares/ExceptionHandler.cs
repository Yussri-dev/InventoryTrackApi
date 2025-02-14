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
                await HandleExceptionAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                message = "An internal server error occurred.\nPlease try again later."
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
