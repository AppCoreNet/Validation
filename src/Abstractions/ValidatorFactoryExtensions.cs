// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;

namespace AppCore.ModelValidation;

/// <summary>
/// Provides extension methods for <see cref="IValidatorFactory"/>.
/// </summary>
public static class ValidatorFactoryExtensions
{
    /// <summary>
    /// Creates a validator for the specified model type.
    /// </summary>
    /// <typeparam name="T">The type of the model to validate.</typeparam>
    /// <param name="factory">The <see cref="IValidatorFactory"/>.</param>
    /// <returns>A new instance of <see cref="IValidator{T}"/>.</returns>
    /// <exception cref="ArgumentNullException">Argument <paramref name="factory"/> must not be <c>null</c>.</exception>
    public static IValidator<T> CreateValidator<T>(this IValidatorFactory factory)
    {
        return new Validator<T>(factory);
    }
}