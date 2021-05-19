// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AppCore.Validation.DataAnnotations
{
    public class DataAnnotationsValidatorTests
    {
        [Fact]
        public async Task ValidateReturnsValidationResult()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

            var validator = new DataAnnotationsValidator(Substitute.For<IServiceProvider>());
            ValidationResult result = await validator.ValidateAsync(new TestModel(), CancellationToken.None);

            result.Errors.Should()
                  .BeEquivalentTo(
                      new ValidationError(
                          nameof(TestModel.Value1),
                          $"The {nameof(TestModel.Value1)} field is required."),
                      new ValidationError(
                          nameof(TestModel.Value2),
                          $"The {nameof(TestModel.Value2)} field is required."));
        }
    }
}
