// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using Microsoft.AspNetCore.Mvc.Filters;

namespace AppCore.ModelValidation.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// An attribute which uses the <see cref="ValidationExceptionFilter"/>.
    /// </summary>
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly ValidationExceptionFilter Filter = new ValidationExceptionFilter();

        /// <summary>
        /// See <see cref="ValidationExceptionFilter.OnException"/>.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public override void OnException(ExceptionContext context)
        {
            Filter.OnException(context);
        }
    }
}