// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.Validation;
using AppCore.Validation.DataAnnotations;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register <see cref="DataAnnotationsExtension"/> with a <see cref="IValidationFacility"/>.
    /// </summary>
    public static class DataAnnotationsRegistrationExtensions
    {
        /// <summary>
        /// Adds capability to use the <see cref="System.ComponentModel.DataAnnotations"/> to validate models.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <returns>The <see cref="IFacilityExtensionBuilder{TFacility, TExtension}"/>.</returns>
        public static IFacilityExtensionBuilder<IValidationFacility, DataAnnotationsExtension> AddDataAnnotations(
            this IFacilityBuilder<IValidationFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<DataAnnotationsExtension>();
        }
    }
}