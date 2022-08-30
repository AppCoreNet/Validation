// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

namespace AppCore.ModelValidation;

/// <summary>
/// Describes the severity of a <see cref="ValidationError"/>.
/// </summary>
public enum ValidationErrorSeverity
{
    /// <summary>
    /// The error has informational reasons.
    /// </summary>
    Info,

    /// <summary>
    /// The error has warning reasons.
    /// </summary>
    Warning,

    /// <summary>
    /// The validation failed; processing cannot continue.
    /// </summary>
    Error
}