// Licensed under the MIT License.
// Copyright (c) 2020-2022 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FV = FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for <see cref="IFluentValidationBuilder"/>.
    /// </summary>
    public static class FluentValidationBuilderExtensions
    {
        public static IFluentValidationBuilder AddValidator<T>(this IFluentValidationBuilder builder)
            where T : FV.IValidator
        {
            return AddValidator(builder, typeof(T));
        }

        public static IFluentValidationBuilder AddValidator(this IFluentValidationBuilder builder, Type validatorType)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            Ensure.Arg.NotNull(validatorType, nameof(validatorType));
            Ensure.Arg.OfType(validatorType, typeof(FV.IValidator<>), nameof(validatorType));

            Type serviceType = validatorType.GetClosedTypeOf(typeof(FV.IValidator<>));
            builder.Services.TryAddTransient(serviceType, validatorType);
            return builder;
        }

        public static IFluentValidationBuilder AddValidatorsFrom(this IFluentValidationBuilder builder, Action<IServiceDescriptorReflectionBuilder> configure)
        {
            Ensure.Arg.NotNull(builder, nameof(builder));
            Ensure.Arg.NotNull(configure, nameof(configure));

            builder.Services.TryAddFrom(typeof(FV.IValidator<>), configure);
            return builder;
        }
    }
}