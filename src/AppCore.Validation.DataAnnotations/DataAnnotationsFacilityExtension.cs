// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Validation;
using AppCore.Validation.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides a extensions for the <see cref="IValidationFacility"/> which adds validation using annotations
    /// from the <see cref="System.ComponentModel.DataAnnotations"/> namespace.
    /// </summary>
    public sealed class DataAnnotationsFacilityExtension : FacilityExtension<IValidationFacility>
    {
        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry, IValidationFacility facility)
        {
            registry.Register<IValidatorProvider>()
                    .Add<DataAnnotationsValidatorProvider>()
                    .PerDependency()
                    .IfNotRegistered();
        }
    }
}
