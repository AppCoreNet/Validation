// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Validation;
using IValidatorFactory = FluentValidation.IValidatorFactory;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides a extensions for the <see cref="IValidationFacility"/> which adds validation using FluentValidation.
    /// </summary>
    public sealed class FluentValidationFacilityExtension : FacilityExtension<IValidationFacility>
    {
        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry, IValidationFacility facility)
        {
            registry.Register<IValidatorProvider>()
                    .Add<FluentValidationValidatorProvider>()
                    .PerDependency()
                    .IfNotRegistered();

            registry.Register<IValidatorFactory>()
                    .Add<ContainerValidatorFactory>()
                    .PerDependency()
                    .IfNoneRegistered();
        }
    }
}