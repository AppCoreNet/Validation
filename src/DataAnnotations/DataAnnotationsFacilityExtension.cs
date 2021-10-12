// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.ModelValidation;
using AppCore.ModelValidation.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    internal class DataAnnotationsFacilityExtension : FacilityExtension
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IValidatorProvider, DataAnnotationsValidatorProvider>());
        }
    }
}