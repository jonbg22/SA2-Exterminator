using System.Net;
using Exterminator.Models;
using Exterminator.Models.Exceptions;
using Exterminator.Services.Implementations;
using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace Exterminator.WebApi.ExceptionHandlerExtensions;

public static class ExceptionHandlerExtensions
{
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                var logService = app.ApplicationServices.GetRequiredService<ILogService>();

                if (exceptionHandlerFeature != null)
                {
                    var exception = exceptionHandlerFeature.Error;
                    // Sets default status code to 500
                    var statusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";


                    // TODO: Make this line work using dependancy injection

                    if (exception is ResourceNotFoundException)
                    {
                        statusCode = (int)HttpStatusCode.NotFound;
                    }
                    if (exception is ModelFormatException)
                    {
                        statusCode = (int)HttpStatusCode.PreconditionFailed;
                    }
                    if (exception is ArgumentOutOfRangeException)
                    {
                        statusCode = (int)HttpStatusCode.BadRequest;
                    }


                    var logException = new ExceptionModel
                    {
                        StatusCode = statusCode,
                        ExceptionMessage = exception.Message,
                        StackTrace = exception.StackTrace
                    };

                    logService.LogToDatabase(logException);
                    
                    await context.Response.WriteAsync(new ExceptionModel 
                    {
                    StatusCode = statusCode,
                    ExceptionMessage = exception.Message
                    }.ToString());
                }
                
            });
        });
    }
}