// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register <see cref="DataAnnotationsFacilityExtension"/> with a <see cref="IValidationFacility"/>.
    /// </summary>
    public static class DataAnnotationsFacilityBuilderExtensions
    {
        /// <summary>
        /// Adds capability to use the <see cref="System.ComponentModel.DataAnnotations"/> to validate models.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <returns>The passed <see cref="IFacilityBuilder{TFacility}"/>.</returns>
        public static IFacilityBuilder<IValidationFacility> UseDataAnnotations(
            this IFacilityBuilder<IValidationFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<DataAnnotationsFacilityExtension>();
        }
    }
}