// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;

namespace AppCore.ModelValidation
{
    /// <summary>
    /// Represents the validation facility.
    /// </summary>
    public sealed class ModelValidationFacility : Facility
    {
        /// <inheritdoc />
        protected override void Build(IComponentRegistry registry)
        {
            base.Build(registry);

            registry.TryAdd(new[]
            {
                ComponentRegistration.Transient<IValidatorFactory, ValidatorFactory>(),
                ComponentRegistration.Transient(typeof(IValidator<>), typeof(Validator<>))
            });
        }
    }
}