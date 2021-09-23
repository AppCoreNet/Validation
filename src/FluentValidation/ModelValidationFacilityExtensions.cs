// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using AppCore.Diagnostics;

namespace AppCore.ModelValidation.FluentValidation
{
    /// <summary>
    /// Provides extension methods to register FluentValidation.
    /// </summary>
    public static class ModelValidationFacilityExtensions
    {
        /// <summary>
        /// Adds validation using FluentValidation.
        /// </summary>
        /// <param name="facility">The <see cref="ModelValidationFacility"/>.</param>
        /// <param name="configure"></param>
        /// <returns>The <see cref="ModelValidationFacility"/>.</returns>
        public static ModelValidationFacility UseFluentValidation(
            this ModelValidationFacility facility,
            Action<FluentValidationFacilityExtension> configure = null)
        {
            Ensure.Arg.NotNull(facility, nameof(facility));
            facility.AddExtension(configure);
            return facility;
        }
    }
}