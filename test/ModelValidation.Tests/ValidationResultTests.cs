// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using FluentAssertions;
using Xunit;

namespace AppCore.ModelValidation
{
    public class ValidationResultTests
    {
        [Theory]
        [InlineData(ValidationErrorSeverity.Info, ValidationErrorSeverity.Warning)]
        [InlineData(ValidationErrorSeverity.Info, ValidationErrorSeverity.Error)]
        [InlineData(ValidationErrorSeverity.Warning, ValidationErrorSeverity.Error)]
        public void IsValidReturnsTrueWhenSeverityIsEqual(ValidationErrorSeverity severity, ValidationErrorSeverity testedSeverity)
        {
            ValidationResult result = ValidationResultFactory.Create(severity);
            result.IsValid(testedSeverity)
                  .Should()
                  .BeTrue();
        }

        [Theory]
        [InlineData(ValidationErrorSeverity.Info, ValidationErrorSeverity.Info)]
        [InlineData(ValidationErrorSeverity.Warning, ValidationErrorSeverity.Info)]
        [InlineData(ValidationErrorSeverity.Error, ValidationErrorSeverity.Info)]
        [InlineData(ValidationErrorSeverity.Warning, ValidationErrorSeverity.Warning)]
        [InlineData(ValidationErrorSeverity.Error, ValidationErrorSeverity.Warning)]
        [InlineData(ValidationErrorSeverity.Error, ValidationErrorSeverity.Error)]

        public void IsValidReturnsTrueWhenSeverityIsHigherOrEqual(ValidationErrorSeverity severity, ValidationErrorSeverity testedSeverity)
        {
            ValidationResult result = ValidationResultFactory.Create(severity);
            result.IsValid(testedSeverity)
                  .Should()
                  .BeFalse();
        }

        [Fact]
        public void SuccessIsValid()
        {
            ValidationResult.Success.IsValid(ValidationErrorSeverity.Info)
                            .Should()
                            .BeTrue();
        }
    }
}
