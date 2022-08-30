// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.Diagnostics;

namespace AppCore.ModelValidation;

/// <summary>
/// Represents a validation exception.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Gets the <see cref="ValidationResult"/> which caused the exception.
    /// </summary>
    public ValidationResult Result { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="result">The <see cref="ValidationResult"/>.</param>
    /// <exception cref="ArgumentNullException">Argument <paramref name="result"/> must not be <c>null</c>.</exception>
    public ValidationException(ValidationResult result)
    {
        Ensure.Arg.NotNull(result);
        Result = result;
    }
}