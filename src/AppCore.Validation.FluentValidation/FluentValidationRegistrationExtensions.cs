// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Builder;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.Validation;
using AppCore.Validation.FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register FluentValidation with a <see cref="IValidationFacility"/>.
    /// </summary>
    public static class FluentValidationRegistrationExtensions
    {
        /// <summary>
        /// Adds capability to use FluentValidation to validate models.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <returns>The <see cref="IFacilityExtensionBuilder{TFacility, TExtension}"/>.</returns>
        public static IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension>
            AddFluentValidation(this IFacilityBuilder<IValidationFacility> builder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.AddExtension<FluentValidationExtension>();
        }

        public static IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension> UseValidators(
            this IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension> builder,
            Action<IRegistrationBuilder, IValidationFacility> register)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            builder.AddExtension(
                new RegistrationFacilityExtension<IValidationFacility>(
                    typeof(FluentValidation.IValidator<>),
                    register));

            return builder;
        }
    }
}