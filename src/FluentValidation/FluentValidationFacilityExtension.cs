// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.ModelValidation.FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FV = FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.ModelValidation
{
    /// <summary>
    /// Provides the FluentValidation extension.
    /// </summary>
    public class FluentValidationFacilityExtension : FacilityExtension
    {
        /// <inheritdoc />
        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.TryAddEnumerable(ServiceDescriptor.Transient<IValidatorProvider, FluentValidationValidatorProvider>());
            services.TryAddTransient<FV.IValidatorFactory, ContainerValidatorFactory>();
        }

        public FluentValidationFacilityExtension WithValidator<T>()
            where T : FV.IValidator
        {
            return WithValidator(typeof(T));
        }

        public FluentValidationFacilityExtension WithValidator(Type validatorType)
        {
            Ensure.Arg.NotNull(validatorType, nameof(validatorType));
            Ensure.Arg.OfType(validatorType, typeof(FV.IValidator<>), nameof(validatorType));

            Type serviceType = validatorType.GetClosedTypeOf(typeof(FV.IValidator<>));
            AddCallback(r => r.TryAddTransient(serviceType, validatorType));

            return this;
        }

        public FluentValidationFacilityExtension WithValidatorsFrom(Action<IServiceDescriptorReflectionBuilder> configure)
        {
            Ensure.Arg.NotNull(configure, nameof(configure));

            AddCallback(r =>
            {
                var sources = new ServiceDescriptorReflectionBuilder(typeof(FV.IValidator<>));
                configure(sources);
                r.TryAdd(sources.Resolve());
            });
            return this;
        }
    }
}