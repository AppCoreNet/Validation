// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;

namespace AppCore.Validation.FluentValidation
{
    /// <summary>
    /// Provides a extensions for the <see cref="IValidationFacility"/> which adds validation using FluentValidation.
    /// </summary>
    public sealed class FluentValidationExtension : FacilityExtension<IValidationFacility>
    {
        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry, IValidationFacility facility)
        {
            registry.Register<IValidatorProvider>()
                    .Add<FluentValidationValidatorProvider>()
                    .PerDependency()
                    .IfNotRegistered();

            registry.Register<global::FluentValidation.IValidatorFactory>()
                    .Add<ContainerValidatorFactory>()
                    .PerDependency()
                    .IfNoneRegistered();
        }
    }
}