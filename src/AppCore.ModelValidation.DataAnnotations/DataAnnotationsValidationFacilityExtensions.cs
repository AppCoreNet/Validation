// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register data annotations validation.
    /// </summary>
    public static class DataAnnotationsValidationFacilityExtensions
    {
        /// <summary>
        /// Adds validation using <see cref="System.ComponentModel.DataAnnotations"/>.
        /// </summary>
        /// <param name="facility">The <see cref="ModelValidationFacility"/>.</param>
        /// <returns>The <see cref="ModelValidationFacility"/>.</returns>
        public static ModelValidationFacility UseDataAnnotations(this ModelValidationFacility facility)
        {
            Ensure.Arg.NotNull(facility, nameof(facility));
            facility.AddExtension<DataAnnotationsValidationExtension>();
            return facility;
        }
    }
}
