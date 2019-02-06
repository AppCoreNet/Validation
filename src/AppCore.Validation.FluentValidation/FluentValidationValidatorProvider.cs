// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.Diagnostics;

namespace AppCore.Validation
{
    /// <summary>
    /// Provides a <see cref="IValidatorProvider"/> which creates <see cref="FluentValidationValidator"/> instances.
    /// </summary>
    public sealed class FluentValidationValidatorProvider : IValidatorProvider
    {
        private readonly FluentValidation.IValidatorFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentValidationValidatorProvider"/> class.
        /// </summary>
        /// <param name="factory">The <see cref="FluentValidation.IValidatorFactory"/> used.</param>
        public FluentValidationValidatorProvider(FluentValidation.IValidatorFactory factory)
        {
            Ensure.Arg.NotNull(factory, nameof(factory));
            _factory = factory;
        }

        /// <inheritdoc />
        public IValidator CreateValidator(Type modelType)
        {
            return new FluentValidationValidator(_factory.GetValidator(modelType));
        }
    }
}
