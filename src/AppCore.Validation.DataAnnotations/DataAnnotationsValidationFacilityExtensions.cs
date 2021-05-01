// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.Diagnostics;
using AppCore.Validation.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace AppCore.Validation
{
    /// <summary>
    /// Provides extension methods to register data annotations validation.
    /// </summary>
    public static class DataAnnotationsValidationFacilityExtensions
    {
        /// <summary>
        /// Adds validation using <see cref="System.ComponentModel.DataAnnotations"/>.
        /// </summary>
        /// <param name="facility">The <see cref="ValidationFacility"/>.</param>
        /// <returns>The <see cref="ValidationFacility"/>.</returns>
        public static IValidationFacility UseDataAnnotations(this IValidationFacility facility)
        {
            Ensure.Arg.NotNull(facility, nameof(facility));

            facility.AddExtension<DataAnnotationsValidationExtension>();
            return facility;
        }
    }
}