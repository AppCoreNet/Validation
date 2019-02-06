// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using FluentValidation;

namespace AppCore.Validation.FluentValidation
{
    public class TestModelValidator : AbstractValidator<TestModel>
    {
        public TestModelValidator()
        {
            RuleFor(m => m.Value1)
                .NotEmpty()
                .WithMessage($"The {nameof(TestModel.Value1)} field is required.");

            RuleFor(m => m.Value2)
                .NotEmpty()
                .WithSeverity(Severity.Warning)
                .WithMessage($"The {nameof(TestModel.Value2)} field is required.");
        }
    }
}