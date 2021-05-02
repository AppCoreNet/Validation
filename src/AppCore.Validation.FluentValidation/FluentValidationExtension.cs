// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using System;
using System.Collections.Generic;
using System.Reflection;
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

        public FluentValidationExtension WithValidatorsFromAssemblies(
            Action<AssemblyRegistrationBuilder> configureAssemblyBuilder)
        {
            Ensure.Arg.NotNull(configureAssemblyBuilder, nameof(configureAssemblyBuilder));

            ConfigureRegistry(r => r.AddFromAssemblies(typeof(FV.IValidator<>), configureAssemblyBuilder));
            return this;
        }

        public FluentValidationExtension WithValidatorsFromAssemblies(IEnumerable<Assembly> assemblies)
        {
            return WithValidatorsFromAssemblies(b => b.From(assemblies));
        }

        public FluentValidationExtension AddValidatorsFromAssembly(Assembly assembly)
        {
            return WithValidatorsFromAssemblies(b => b.From(assembly));
        }
    }
}