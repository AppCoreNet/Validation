// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using AppCore.Validation;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection.Facilities
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

            registry.TryAdd(new[]
            {
                ComponentRegistration.Transient<IValidatorFactory, ValidatorFactory>(),
                ComponentRegistration.Transient(typeof(IValidator<>), typeof(Validator<>))
            });
        }
    }
}