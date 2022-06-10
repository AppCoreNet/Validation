// Licensed under the MIT License.
// Copyright (c) 2020-2022 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using AppCore.ModelValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register model validation.
    /// </summary>
    public static class AppCoreBuilderExtensions
    {
        /// <summary>
        /// Adds the model validation services to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IAppCoreBuilder"/>.</param>
        /// <returns>The <see cref="IModelValidationBuilder"/>.</returns>
        public static IModelValidationBuilder AddModelValidation(this IAppCoreBuilder builder)
        {
            Ensure.Arg.NotNull(builder);

            IServiceCollection services = builder.Services;
            services.TryAddTransient<IValidatorFactory, ValidatorFactory>();
            services.TryAddTransient(typeof(IValidator<>), typeof(Validator<>));

            return new ModelValidationBuilder(services);
        }
    }
}