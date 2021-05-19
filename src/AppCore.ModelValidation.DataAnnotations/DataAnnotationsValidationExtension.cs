// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.Validation;
using AppCore.Validation.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection.Facilities
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