using MedicineCard.Exceptions;
using MedicineCard.Logger;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MedicineCard.ExceptionHandlers
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionHandler(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                //next pipeline method
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            if (exception is NotFoundException) context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            if (exception is ServerErrorException) context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //узнать тип экзепшна и вернуть нужный ответ.           
            return context.Response.WriteAsync(exception.Message);
        }
    }
}
