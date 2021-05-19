// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;
using AppCore.ModelValidation.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace AppCore.ModelValidation
{
    internal class DataAnnotationsFacilityExtension : FacilityExtension
    {
        protected override void Build(IComponentRegistry registry)
        {
            base.Build(registry);

            registry.TryAddEnumerable(
                ComponentRegistration.Transient<IValidatorProvider, DataAnnotationsValidatorProvider>());
        }
    }
}