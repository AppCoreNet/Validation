// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.Validation.FluentValidation;
using FV = FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.Validation
{
    /// <summary>
    /// Provides the FluentValidation extension.
    /// </summary>
    public class FluentValidationExtension : FacilityExtension
    {
        /// <inheritdoc />
        protected override void Build(IComponentRegistry registry)
        {
            base.Build(registry);

            registry.TryAddEnumerable(ComponentRegistration.Transient<IValidatorProvider, FluentValidationValidatorProvider>());
            registry.TryAdd(ComponentRegistration.Transient<FV.IValidatorFactory, ContainerValidatorFactory>());
        }

        public FluentValidationExtension WithValidator<T>()
            where T : FV.IValidator
        {
            return WithValidator(typeof(T));
        }

        public FluentValidationExtension WithValidator(Type validatorType)
        {
            Ensure.Arg.NotNull(validatorType, nameof(validatorType));

            Type serviceType = validatorType.GetClosedTypeOf(typeof(FV.IValidator<>));
            ConfigureRegistry(r => r.TryAdd(ComponentRegistration.Transient(serviceType, validatorType)));

            return this;
        }

        public FluentValidationExtension WithValidatorsFrom(Action<IComponentRegistrationSources> configure)
        {
            Ensure.Arg.NotNull(configure, nameof(configure));

            ConfigureRegistry(r =>
            {
                var sources = new ComponentRegistrationSources()
                    .WithContract(typeof(FV.IValidator<>))
                    .WithDefaultLifetime(ComponentLifetime.Transient);

                configure(sources);
                r.TryAdd(sources.BuildRegistrations());
            });
            return this;
        }
    }
}