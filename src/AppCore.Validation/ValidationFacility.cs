// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Validation;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Represents the validation facility.
    /// </summary>
    public sealed class ValidationFacility : Facility, IValidationFacility
    {
        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry)
        {
            registry.Register<IValidatorFactory>()
                    .Add<ValidatorFactory>()
                    .PerDependency()
                    .IfNoneRegistered();

            registry.Register(typeof(IValidator<>))
                    .Add(typeof(Validator<>))
                    .PerDependency()
                    .IfNoneRegistered();
        }
    }
}