// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Facilities;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register the <see cref="ValidationFacility"/>.
    /// </summary>
    public static class ValidationRegistrationExtensions
    {
        /// <summary>
        /// Adds the <see cref="ValidationFacility"/> to the <see cref="IComponentRegistry"/>.
        /// </summary>
        /// <param name="registry">The <see cref="IComponentRegistry"/>.</param>
        /// <param name="configure">The configuration delegate.</param>
        /// <returns>The <see cref="IComponentRegistry"/>.</returns>
        public static IComponentRegistry AddValidation(
            this IComponentRegistry registry,
            Action<ValidationFacility> configure = null)
        {
            return registry.AddFacility(configure);
        }
    }
}