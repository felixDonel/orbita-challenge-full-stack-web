using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Orbita.Model.Exceptions;
using System.Text.Json;

namespace Orbita.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            IActionResult result = GetActionResultForException(ex);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCodeForException(ex);

            if (result is ObjectResult objectResult)
            {
                var json = JsonSerializer.Serialize(objectResult.Value);
                return context.Response.WriteAsync(json);
            }
            else
            {
                return Task.CompletedTask;
            }
        }

        private IActionResult GetActionResultForException(Exception ex)
        {
            if (ex is NotFoundException)
            {
                return new NotFoundObjectResult(ex.Message);
            }
            else if (ex is ValidationException)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            else
            {
                return new ObjectResult("Erro interno do servidor") { StatusCode = 500 };
            }
        }

        private int GetStatusCodeForException(Exception ex)
        {
            if (ex is NotFoundException)
            {
                return 404;
            }
            else if (ex is ValidationException)
            {
                return 400;
            }
            else
            {
                return 500;
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
