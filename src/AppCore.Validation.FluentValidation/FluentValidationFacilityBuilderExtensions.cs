// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Builder;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods to register FluentValidation with a <see cref="IValidationFacility"/>.
    /// </summary>
    public static class FluentValidationFacilityBuilderExtensions
    {
        /// <summary>
        /// Adds capability to use FluentValidation to validate models.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityBuilder{TFacility}"/>.</param>
        /// <param name="registrationBuilder">A <see cref="IRegistrationBuilder"/> to register <see cref="IValidator{T}"/> types.</param>
        /// <returns>The passed <see cref="IFacilityBuilder{TFacility}"/>.</returns>
        public static IFacilityBuilder<IValidationFacility> UseFluentValidation(
            this IFacilityBuilder<IValidationFacility> builder,
            Action<IRegistrationBuilder> registrationBuilder)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            Ensure.Arg.NotNull(registrationBuilder, nameof(registrationBuilder));

            builder.AddExtension<FluentValidationFacilityExtension>();
            return builder.AddExtension(
                new DelegateRegistrationFacilityExtension(
                    typeof(IValidator<>),
                    (r, f) =>
                    {
                        registrationBuilder(r);
                    }));
        }
    }
}