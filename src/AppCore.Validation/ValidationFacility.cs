// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;

namespace AppCore.Validation
{
    /// <summary>
    /// Represents the validation facility.
    /// </summary>
    public sealed class ValidationFacility : Facility
    {
        /// <inheritdoc />
        protected override void Build(IComponentRegistry registry)
        {
            base.Build(registry);

            registry.TryAdd(ComponentRegistration.Transient<IValidatorFactory, ValidatorFactory>());
            registry.TryAdd(ComponentRegistration.Transient(typeof(IValidator<>), typeof(Validator<>)));
        }
    }
}