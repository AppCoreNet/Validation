// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System.Linq;
using AppCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppCore.ModelValidation.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// Provides a exception filter which returns <see cref="BadRequestObjectResult"/> with a <see cref="ValidationProblemDetails"/>
    /// payload when a <see cref="ValidationException"/> is thrown.
    /// </summary>
    public class ValidationExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Creates a <see cref="BadRequestObjectResult"/> with <see cref="ValidationProblemDetails"/> payload
        /// if the exception is of type <see cref="ValidationException"/>.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public void OnException(ExceptionContext context)
        {
            Ensure.Arg.NotNull(context, nameof(context));

            if (!(context.Exception is ValidationException validationException))
                return;

            context.ExceptionHandled = true;
            context.Result = new BadRequestObjectResult(InitProblemDetails(new ValidationProblemDetails(), validationException));
        }

        /// <summary>
        /// Can be overridden to initialize the <see cref="ValidationProblemDetails"/>.
        /// </summary>
        /// <param name="details">The <see cref="ValidationProblemDetails"/>.</param>
        /// <param name="exception">The <see cref="ValidationException"/>.</param>
        /// <returns>The initialized <see cref="ValidationProblemDetails"/>.</returns>
        protected virtual ValidationProblemDetails InitProblemDetails(ValidationProblemDetails details, ValidationException exception)
        {
            details.Title = SR.ValidationProblemDetails_Title;

            var errorsByProperties =
                exception.Result.Errors
                                   .Where(e => e.Severity >= ValidationErrorSeverity.Error)
                                   .GroupBy(e => e.PropertyName)
                                   .Select(
                                       g => new
                                       {
                                           PropertyName = g.Key,
                                           ErrorMessages = g.Select(em => em.ErrorMessage)
                                                            .ToArray()
                                       });

            foreach (var errorsByProperty in errorsByProperties)
            {
                details.Errors.Add(errorsByProperty.PropertyName, errorsByProperty.ErrorMessages);
            }

            return details;
        }
    }
}