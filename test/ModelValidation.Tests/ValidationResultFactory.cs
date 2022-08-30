// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

namespace AppCore.ModelValidation;

public static class ValidationResultFactory
{
    public static ValidationResult Create(ValidationErrorSeverity severity = ValidationErrorSeverity.Error)
    {
        return new ValidationResult(new[] {new ValidationError("a", "error", severity)});
    }
}