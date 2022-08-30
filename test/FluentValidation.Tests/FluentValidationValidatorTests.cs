// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace AppCore.ModelValidation.FluentValidation;

public class FluentValidationValidatorTests
{
    [Fact]
    public async Task ValidateReturnsValidationResult()
    {
        var validator = new FluentValidationValidator(new TestModelValidator());
        ValidationResult result = await validator.ValidateAsync(new TestModel(), CancellationToken.None);

        result.Errors.Should()
              .BeEquivalentTo(
                  new[]
                  {
                      new ValidationError(
                          nameof(TestModel.Value1),
                          $"The {nameof(TestModel.Value1)} field is required."),
                      new ValidationError(
                          nameof(TestModel.Value2),
                          $"The {nameof(TestModel.Value2)} field is required.",
                          ValidationErrorSeverity.Warning)
                  });
    }
}