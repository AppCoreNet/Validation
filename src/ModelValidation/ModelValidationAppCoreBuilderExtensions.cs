// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection;
using AppCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace AppCore.ModelValidation
{
    /// <summary>
    /// Provides extension methods to register the <see cref="ModelValidationFacility"/>.
    /// </summary>
    public static class ModelValidationAppCoreBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="ModelValidationFacility"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IAppCoreBuilder"/>.</param>
        /// <param name="configure">The configuration delegate.</param>
        /// <returns>The <see cref="IAppCoreBuilder"/>.</returns>
        public static IAppCoreBuilder AddModelValidation(
            this IAppCoreBuilder builder,
            Action<ModelValidationFacility> configure = null)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            builder.Services.AddFacility(configure);
            return builder;
        }
    }
}