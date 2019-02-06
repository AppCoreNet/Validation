// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppCore.Diagnostics;
using FluentValidation;
using FluentValidation.Results;

namespace AppCore.Validation
{
    /// <summary>
    /// Provides a <see cref="IValidator"/> which uses FluentValidation.
    /// </summary>
    public sealed class FluentValidationValidator : IValidator
    {
        private readonly FluentValidation.IValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentValidationValidator"/>.
        /// </summary>
        /// <param name="validator">The <see cref="FluentValidation.IValidator"/>.</param>
        public FluentValidationValidator(FluentValidation.IValidator validator)
        {
            Ensure.Arg.NotNull(validator, nameof(validator));
            _validator = validator;
        }

        /// <inheritdoc />
        public async ValueTask<ValidationResult> ValidateAsync(object model, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(model, cancellationToken);
            if (!result.IsValid)
            {
                return new ValidationResult(result.Errors.Select(CreateValidationError));
            }

            return ValidationResult.Success;
        }

        private static ValidationError CreateValidationError(ValidationFailure e)
        {
            ValidationErrorSeverity severity;
            switch (e.Severity)
            {
                case Severity.Error:
                    severity = ValidationErrorSeverity.Error;
                    break;
                case Severity.Warning:
                    severity = ValidationErrorSeverity.Warning;
                    break;
                case Severity.Info:
                    severity = ValidationErrorSeverity.Info;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ValidationError(e.PropertyName, e.ErrorMessage, severity);
        }
    }
}