// Licensed under the MIT License.
// Copyright (c) 2020-2022 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using AppCore.ModelValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace AppCore.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register model validation.
    /// </summary>
    public static class ModelValidationAppCoreBuilderExtensions
    {
        /// <summary>
        /// Adds the model validation services to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IAppCoreBuilder"/>.</param>
        /// <param name="configure">Delegate to configure the <see cref="IModelValidationBuilder"/>.</param>
        /// <returns>The <see cref="IAppCoreBuilder"/>.</returns>
        public static IAppCoreBuilder AddModelValidation(this IAppCoreBuilder builder, Action<IModelValidationBuilder>? configure = null)
        {
            Ensure.Arg.NotNull(builder);

            IServiceCollection services = builder.Services;
            services.TryAddTransient<IValidatorFactory, ValidatorFactory>();
            services.TryAddTransient(typeof(IValidator<>), typeof(Validator<>));

            configure?.Invoke(new ModelValidationBuilder(services));

            return builder;
        }
    }
}