// Licensed under the MIT License.
// Copyright (c) 2018-2022 the AppCore .NET project.

using AppCore.Diagnostics;
using AppCore.ModelValidation;
using AppCore.ModelValidation.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register data annotations validation.
    /// </summary>
    public static class ModelValidationBuilderExtensions
    {
        /// <summary>
        /// Adds validation using <see cref="System.ComponentModel.DataAnnotations"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IModelValidationBuilder"/>.</param>
        /// <returns>The <see cref="IModelValidationBuilder"/>.</returns>
        public static IModelValidationBuilder AddDataAnnotations(this IModelValidationBuilder builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));

            IServiceCollection services = builder.Services;

            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IValidatorProvider, DataAnnotationsValidatorProvider>());

            return builder;
        }
    }
}
