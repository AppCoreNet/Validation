// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.Diagnostics;

namespace AppCore.ModelValidation;

/// <summary>
/// Represents an error which occured when validating a object.
/// </summary>
public class ValidationError
{
    /// <summary>
    /// Gets the severity of the validation error.
    /// </summary>
    public ValidationErrorSeverity Severity { get; }

    /// <summary>
    /// Gets the name of the property which failed validation.
    /// </summary>
    /// <remarks>
    /// Depending on the implementation this might be the display name of the property.
    /// </remarks>
    public string PropertyName { get; }

    /// <summary>
    /// Gets a message describing the validation error.
    /// </summary>
    public string ErrorMessage { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class.
    /// </summary>
    /// <param name="propertyName">The name of the property which failed validation.</param>
    /// <param name="errorMessage">The message describing the validation error.</param>
    /// <param name="severity">The severity of the validation error.</param>
    /// <exception cref="ArgumentNullException">
    ///     Argument <paramref name="propertyName"/> and <paramref name="errorMessage"/> must not be <c>null</c>.
    /// </exception>
    public ValidationError(
        string propertyName,
        string errorMessage,
        ValidationErrorSeverity severity = ValidationErrorSeverity.Error)
    {
        Ensure.Arg.NotNull(propertyName);
        Ensure.Arg.NotNull(errorMessage);

        Severity = severity;
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}