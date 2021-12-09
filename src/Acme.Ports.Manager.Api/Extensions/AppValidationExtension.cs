using System.Linq;
using System.Text;
using System.Text.Json;
using Acme.Ports.Manager.Core.Ports.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Acme.Ports.Manager.Api.Extensions
{
    public static class AppValidationExtension
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if(exception is not PortDomainException portDomainException)
                        throw exception;

                    var validationException = (ValidationException)portDomainException.InnerException;

                    var errors = validationException.Errors.Select(err => new 
                    { 
                        err.PropertyName,
                        err.ErrorMessage
                    });

                    var errorText = JsonSerializer.Serialize(errors);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorText, Encoding.UTF8);
                });
            });
        }
    }
}
