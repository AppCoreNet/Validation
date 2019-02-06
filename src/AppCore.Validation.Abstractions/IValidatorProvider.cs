// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;

namespace AppCore.Validation
{
    /// <summary>
    /// Provides an implementation of <see cref="IValidator"/>.
    /// </summary>
    public interface IValidatorProvider
    {
        /// <summary>
        /// Creates a <see cref="IValidator"/> implementation which can be used to validate objects
        /// of the given type.
        /// </summary>
        /// <param name="modelType">The type of the object which will be validated.</param>
        /// <returns>A reference to the <see cref="IValidator"/>.</returns>
        IValidator CreateValidator(Type modelType);
    }
}