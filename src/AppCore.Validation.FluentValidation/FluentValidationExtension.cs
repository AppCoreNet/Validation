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
        protected override void Build(IComponentRegistry registry)
        {
            base.Build(registry);

            registry.TryAddEnumerable(ComponentRegistration.Transient<IValidatorProvider, FluentValidationValidatorProvider>());
            registry.TryAdd(ComponentRegistration.Transient<FV.IValidatorFactory, ContainerValidatorFactory>());
        }

        public FluentValidationExtension AddValidator<T>()
            where T : FV.IValidator
        {
            return AddValidator(typeof(T));
        }

        public FluentValidationExtension AddValidator(Type validatorType)
        {
            Ensure.Arg.NotNull(validatorType, nameof(validatorType));

            Type serviceType = validatorType.GetClosedTypeOf(typeof(FV.IValidator<>));
            Register(r => r.TryAdd(ComponentRegistration.Transient(serviceType, validatorType)));

            return this;
        }

        public FluentValidationExtension AddValidatorsFromAssemblies(
            Action<AssemblyRegistrationBuilder> configureAssemblyBuilder)
        {
            Ensure.Arg.NotNull(configureAssemblyBuilder, nameof(configureAssemblyBuilder));

            Register(r => r.AddFromAssemblies(b =>
            {
                b.ForType(typeof(FV.IValidator<>));
                configureAssemblyBuilder(b);
            }));

            return this;
        }

        public FluentValidationExtension AddValidatorsFromAssemblies(IEnumerable<Assembly> assemblies)
        {
            return AddValidatorsFromAssemblies(b => b.WithAssemblies(assemblies));
        }

        public FluentValidationExtension AddValidatorsFromAssembly(Assembly assembly)
        {
            return AddValidatorsFromAssemblies(b => b.WithAssembly(assembly));
        }
    }
}