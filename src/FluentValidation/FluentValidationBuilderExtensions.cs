// Licensed under the MIT License.
// Copyright (c) 2020-2022 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FV = FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for <see cref="IFluentValidationBuilder"/>.
/// </summary>
public static class FluentValidationBuilderExtensions
{
    /// <summary>
    /// Adds a validator of the specified <typeparamref name="T"/> to the DI container.
    /// </summary>
    /// <param name="builder">The <see cref="IFluentValidationBuilder"/>.</param>
    /// <typeparam name="T">The type of the validator.</typeparam>
    /// <returns>The <see cref="IFluentValidationBuilder"/>.</returns>
    public static IFluentValidationBuilder AddValidator<T>(this IFluentValidationBuilder builder)
        where T : FV.IValidator
    {
        return AddValidator(builder, typeof(T));
    }

    /// <summary>
    /// Adds a validator of the specified <paramref name="validatorType"/> to the DI container.
    /// </summary>
    /// <param name="builder">The <see cref="IFluentValidationBuilder"/>.</param>
    /// <param name="validatorType">The type of the validator.</param>
    /// <returns>The <see cref="IFluentValidationBuilder"/>.</returns>
    public static IFluentValidationBuilder AddValidator(this IFluentValidationBuilder builder, Type validatorType)
    {
        Ensure.Arg.NotNull(builder);
        Ensure.Arg.NotNull(validatorType);
        Ensure.Arg.OfType(validatorType, typeof(FV.IValidator<>));

        Type serviceType = validatorType.GetClosedTypeOf(typeof(FV.IValidator<>));
        builder.Services.TryAddTransient(serviceType, validatorType);
        return builder;
    }

    /// <summary>
    /// Adds validators to the DI container by dynamically resolving them.
    /// </summary>
    /// <param name="builder">The <see cref="IFluentValidationBuilder"/>.</param>
    /// <param name="configure">The configuration delegate.</param>
    /// <returns>The <see cref="IFluentValidationBuilder"/>.</returns>
    public static IFluentValidationBuilder AddValidatorsFrom(this IFluentValidationBuilder builder, Action<IServiceDescriptorReflectionBuilder> configure)
    {
        Ensure.Arg.NotNull(builder);
        Ensure.Arg.NotNull(configure);

        builder.Services.TryAddFrom(typeof(FV.IValidator<>), configure);
        return builder;
    }
}