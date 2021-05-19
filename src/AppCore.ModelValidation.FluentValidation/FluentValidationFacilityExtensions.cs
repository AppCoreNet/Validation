// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register FluentValidation.
    /// </summary>
    public static class FluentValidationFacilityExtensions
    {
        /// <summary>
        /// Adds validation using FluentValidation.
        /// </summary>
        /// <param name="facility">The <see cref="ValidationFacility"/>.</param>
        /// <param name="configure"></param>
        /// <returns>The <see cref="ValidationFacility"/>.</returns>
        public static ValidationFacility UseFluentValidation(
            this ValidationFacility facility,
            Action<FluentValidationExtension> configure = null)
        {
            Ensure.Arg.NotNull(facility, nameof(facility));
            facility.AddExtension(configure);
            return facility;
        }
    }
}