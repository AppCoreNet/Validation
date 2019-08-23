// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System.Linq;
using AppCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppCore.Validation.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// Provides a exception filter which returns <see cref="BadRequestObjectResult"/> with a <see cref="ValidationProblemDetails"/>
    /// payload when a <see cref="ValidationException"/> is thrown.
    /// </summary>
    public class ValidationExceptionFilter : IExceptionFilter
    {
        /// <inheritdoc />
        public void OnException(ExceptionContext context)
        {
            Ensure.Arg.NotNull(context, nameof(context));

            if (!(context.Exception is ValidationException validationException))
                return;

            context.ExceptionHandled = true;
            context.Result = new BadRequestObjectResult(CreateProblemDetails(validationException));
        }

        private static ValidationProblemDetails CreateProblemDetails(ValidationException validationException)
        {
            var details = new ValidationProblemDetails
            {
                Title = SR.ValidationProblemDetails_Title
            };

            var errorsByProperties = validationException
                                     .Result.Errors.Where(e => e.Severity >= ValidationErrorSeverity.Error)
                                     .GroupBy(e => e.PropertyName)
                                     .Select(
                                         g => new
                                         {
                                             PropertyName = g.Key,
                                             ErrorMessages = g.Select(em => em.ErrorMessage).ToArray()
                                         });

            foreach (var errorsByProperty in errorsByProperties)
            {
                details.Errors.Add(errorsByProperty.PropertyName, errorsByProperty.ErrorMessages);
            }

            return details;
        }
    }
}