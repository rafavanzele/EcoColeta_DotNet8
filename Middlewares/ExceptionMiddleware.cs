using System.Text.Json;
using EcoColeta.Api.Configurations;

namespace EcoColeta.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RecursoNaoEncontradoException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    status = 404,
                    mensagem = ex.Message
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response)
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    status = 500,
                    mensagem = ex.Message
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response)
                );
            }
        }
    }
}