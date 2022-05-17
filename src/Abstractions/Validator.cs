// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Threading;
using System.Threading.Tasks;
using AppCore.Diagnostics;

namespace AppCore.ModelValidation
{
    /// <summary>
    /// Represents a typed validator.
    /// </summary>
    /// <typeparam name="T">The type of the model.</typeparam>
    public sealed class Validator<T> : IValidator<T>
    {
        private readonly IValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator{T}"/> class.
        /// </summary>
        /// <param name="factory">The <see cref="IValidatorFactory"/> used to create the validator.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="factory"/> must not be <c>null</c>.</exception>
        public Validator(IValidatorFactory factory)
        {
            Ensure.Arg.NotNull(factory);
            _validator = factory.CreateValidator(typeof(T));
        }

        /// <inheritdoc />
        public async ValueTask<ValidationResult> ValidateAsync(T model, CancellationToken cancellationToken)
        {
            Ensure.Arg.NotNull(model);
            return await _validator.ValidateAsync(model, cancellationToken);
        }
    }
}