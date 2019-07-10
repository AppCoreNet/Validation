// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

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
        /// <param name="configure">The delegate which is invoked to configure the extension.</param>
        /// <returns>The <see cref="IFacilityExtensionBuilder{TFacility, TExtension}"/>.</returns>
        public static IFacilityBuilder<IValidationFacility>
            AddFluentValidation(
                this IFacilityBuilder<IValidationFacility> builder,
                Action<IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension>> configure = null)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            return builder.Add(configure);
        }

        /// <summary>
        /// Registers <see cref="FluentValidation.IValidator{T}"/> components.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityExtensionBuilder{TFacility, TExtension}"/>.</param>
        /// <param name="register">The validator registration action.</param>
        /// <returns>The <see cref="IFacilityExtensionBuilder{TFacility, TExtension}"/>.</returns>
        public static IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension> AddValidators(
            this IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension> builder,
            Action<IRegistrationBuilder, IValidationFacility> register)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            Ensure.Arg.NotNull(register, nameof(register));
            
            builder.Configure((f,e) => e.AddValidators(register));
            return builder;
        }

        /// <summary>
        /// Registers <see cref="FluentValidation.IValidator{T}"/> components.
        /// </summary>
        /// <param name="builder">The <see cref="IFacilityExtensionBuilder{TFacility, TExtension}"/>.</param>
        /// <param name="register">The validator registration action.</param>
        /// <returns>The <see cref="IFacilityExtensionBuilder{TFacility, TExtension}"/>.</returns>
        public static IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension> AddValidators(
            this IFacilityExtensionBuilder<IValidationFacility, FluentValidationExtension> builder,
            Action<IRegistrationBuilder> register)
        {
            return builder.AddValidators((r, _) => register(r));
        }
    }
}