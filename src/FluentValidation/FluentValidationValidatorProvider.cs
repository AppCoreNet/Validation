// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using FV = FluentValidation;

namespace AppCore.ModelValidation.FluentValidation
{
    /// <summary>
    /// Provides a <see cref="IValidatorProvider"/> which creates <see cref="FluentValidationValidator"/> instances.
    /// </summary>
    public sealed class FluentValidationValidatorProvider : IValidatorProvider
    {
        private readonly FV.IValidatorFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentValidationValidatorProvider"/> class.
        /// </summary>
        /// <param name="factory">The <see cref="FV.IValidatorFactory"/> used.</param>
        public FluentValidationValidatorProvider(FV.IValidatorFactory factory)
        {
            Ensure.Arg.NotNull(factory, nameof(factory));
            _factory = factory;
        }

        /// <inheritdoc />
        public IValidator CreateValidator(Type modelType)
        {
            FV.IValidator validator = _factory.GetValidator(modelType);
            return validator != null
                ? (IValidator) new FluentValidationValidator(validator)
                : NullValidator.Instance;
        }
    }
}
