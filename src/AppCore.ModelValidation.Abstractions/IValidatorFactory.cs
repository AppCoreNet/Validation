// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;

namespace AppCore.Validation
{
    /// <summary>
    /// Represents a factory for creating instances of <see cref="IValidator"/>.
    /// </summary>
    public interface IValidatorFactory
    {
        /// <summary>
        /// Creates a <see cref="IValidator"/> implementation which can be used to validate objects
        /// of the given type.
        /// </summary>
        /// <param name="modelType">The type of the object which will be validated.</param>
        /// <returns>A reference to the <see cref="IValidator"/>.</returns>
        /// <exception cref="ArgumentNullException">Argument <paramref name="modelType"/> must not be <c>null</c>.</exception>
        IValidator CreateValidator(Type modelType);
    }
}