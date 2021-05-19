// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Threading;
using System.Threading.Tasks;

namespace AppCore.Validation
{
    /// <summary>
    /// Represents a model validator.
    /// </summary>
    /// <seealso cref="ValidationResult"/>
    public interface IValidator
    {
        /// <summary>
        /// Validates the given object and returns the <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="model">The object to validate.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> which can be used to cancel the process.</param>
        /// <returns>The <see cref="ValidationResult"/>.</returns>
        ValueTask<ValidationResult> ValidateAsync(object model, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Represents a model validator.
    /// </summary>
    /// <typeparam name="T">The type of the model which is being validated.</typeparam>
    /// <seealso cref="ValidationResult"/>
    public interface IValidator<in T>
    {
        /// <summary>
        /// Validates the given object and returns the <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="model">The object to validate.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> which can be used to cancel the process.</param>
        /// <returns>The <see cref="ValidationResult"/>.</returns>
        ValueTask<ValidationResult> ValidateAsync(T model, CancellationToken cancellationToken = default);
    }
}
