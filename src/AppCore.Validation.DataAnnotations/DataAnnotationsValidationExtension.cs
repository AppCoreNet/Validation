// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;
using AppCore.Validation.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace AppCore.Validation
{
    internal class DataAnnotationsValidationExtension : FacilityExtension
    {
        protected override void Build(IComponentRegistry registry)
        {
            base.Build(registry);

            registry.TryAddEnumerable(
                ComponentRegistration.Transient<IValidatorProvider, DataAnnotationsValidatorProvider>());
        }
    }
}