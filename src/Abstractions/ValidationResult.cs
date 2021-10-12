// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Collections.Generic;
using System.Linq;
using AppCore.Diagnostics;

namespace AppCore.ModelValidation
{
    /// <summary>
    /// Represents the result of a model validation.
    /// </summary>
    /// <seealso cref="IValidator"/>
    /// <seealso cref="IValidator{T}"/>
    public class ValidationResult
    {
        /// <summary>
        /// Gets a <see cref="ValidationResult"/> which has no errors.
        /// </summary>
        public static readonly ValidationResult Success = new ValidationResult(Enumerable.Empty<ValidationError>());

        /// <summary>
        /// Gets the collection of <see cref="ValidationError"/>.
        /// </summary>
        public IReadOnlyList<ValidationError> Errors { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        /// <param name="errors">The <see cref="IEnumerable{T}"/> of <see cref="ValidationError"/>.</param>
        public ValidationResult(IEnumerable<ValidationError> errors)
        {
            Ensure.Arg.NotNull(errors, nameof(errors));
            Errors = errors.ToList();
        }

        /// <summary>
        /// Gets a value indicating whether the result contains with the specified or higher severity.
        /// </summary>
        /// <param name="severity"></param>
        /// <returns></returns>
        public bool IsValid(ValidationErrorSeverity severity = ValidationErrorSeverity.Error)
        {
            return Errors.All(e => e.Severity < severity);
        }
    }
}