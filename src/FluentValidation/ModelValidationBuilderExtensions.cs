// Licensed under the MIT License.
// Copyright (c) 2018-2022 the AppCore .NET project.

using AppCore.Diagnostics;
using AppCore.ModelValidation;
using AppCore.ModelValidation.FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FV = FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register FluentValidation.
    /// </summary>
    public static class ModelValidationBuilderExtensions
    {
        /// <summary>
        /// Adds validation using FluentValidation.
        /// </summary>
        /// <param name="builder">The <see cref="IModelValidationBuilder"/>.</param>
        /// <returns>The <see cref="IFluentValidationBuilder"/>.</returns>
        public static IFluentValidationBuilder AddFluentValidation(this IModelValidationBuilder builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));

            IServiceCollection services = builder.Services;

            services.TryAddEnumerable(ServiceDescriptor.Transient<IValidatorProvider, FluentValidationValidatorProvider>());
            services.TryAddTransient<FV.IValidatorFactory, ContainerValidatorFactory>();

            return new FluentValidationBuilder(services);
        }
    }
}