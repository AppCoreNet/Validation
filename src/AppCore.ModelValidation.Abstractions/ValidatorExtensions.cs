// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Threading;
using System.Threading.Tasks;
using AppCore.Diagnostics;

namespace AppCore.Validation
{
    /// <summary>
    /// Provides extensions methods for <see cref="IValidator"/> and <see cref="IValidator{T}"/>.
    /// </summary>
    public static class ValidatorExtensions
    {
        /// <summary>
        /// Validates the given object and throws <see cref="ValidationException"/> if the validation
        /// results in at least one error with minimum specified severity.
        /// </summary>
        /// <param name="validator">The <see cref="IValidator"/>.</param>
        /// <param name="model">The object to validate.</param>
        /// <param name="severity">Minimum severity of validation error before an exception is thrown.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> which can be used to cancel the process.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="validator"/> must not be <c>null</c>.</exception>
        public static async ValueTask ValidateAndThrowAsync(
            this IValidator validator,
            object model,
            ValidationErrorSeverity severity = ValidationErrorSeverity.Error,
            CancellationToken cancellationToken = default)
        {
            Ensure.Arg.NotNull(validator, nameof(validator));

            ValidationResult result = await validator.ValidateAsync(model, cancellationToken);
            if (!result.IsValid(severity))
                throw new ValidationException(result);
        }

        /// <summary>
        /// Validates the given object and throws <see cref="ValidationException"/> if the validation
        /// results in at least one error with minimum specified severity.
        /// </summary>
        /// <param name="validator">The <see cref="IValidator{T}"/>.</param>
        /// <param name="model">The object to validate.</param>
        /// <param name="severity">Minimum severity of validation error before an exception is thrown.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> which can be used to cancel the process.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="validator"/> must not be <c>null</c>.</exception>
        public static async ValueTask ValidateAndThrowAsync<T>(
            this IValidator<T> validator,
            T model,
            ValidationErrorSeverity severity = ValidationErrorSeverity.Error,
            CancellationToken cancellationToken = default)
        {
            Ensure.Arg.NotNull(validator, nameof(validator));

            ValidationResult result = await validator.ValidateAsync(model, cancellationToken);
            if (!result.IsValid(severity))
                throw new ValidationException(result);
        }
    }
}
