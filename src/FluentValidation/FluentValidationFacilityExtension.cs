// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.ModelValidation;
using AppCore.ModelValidation.FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FV = FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
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
            ConfigureServices(r => r.TryAddTransient(serviceType, validatorType));

            return this;
        }

        public FluentValidationFacilityExtension WithValidatorsFrom(Action<IServiceDescriptorReflectionBuilder> configure)
        {
            Ensure.Arg.NotNull(configure, nameof(configure));

            ConfigureServices(s =>
            {
                s.TryAddFrom(typeof(FV.IValidator<>), configure);
            });
            return this;
        }
    }
}