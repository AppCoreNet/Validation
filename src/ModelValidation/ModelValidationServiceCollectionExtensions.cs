// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using System;
using AppCore.ModelValidation;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register the <see cref="ModelValidationFacility"/>.
    /// </summary>
    public static class ModelValidationServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ModelValidationFacility"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configure">The configuration delegate.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddModelValidation(
            this IServiceCollection services,
            Action<ModelValidationFacility> configure = null)
        {
            return services.AddFacility(configure);
        }
    }
}