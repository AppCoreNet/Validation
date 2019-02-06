// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AppCore.Validation
{
    public class CompositeValidatorTests
    {
        [Fact]
        public async Task ValidateInvokesAllValidators()
        {
            var validator1 = Substitute.For<IValidator>();
            validator1.ValidateAsync(Arg.Any<object>(), Arg.Any<CancellationToken>())
                      .Returns(new ValidationResult(Enumerable.Empty<ValidationError>()));

            var validator2 = Substitute.For<IValidator>();
            validator2.ValidateAsync(Arg.Any<object>(), Arg.Any<CancellationToken>())
                      .Returns(new ValidationResult(Enumerable.Empty<ValidationError>()));

            var compositeValidator = new CompositeValidator(new []{validator1, validator2});

            var obj = "abc";
            var ct = new CancellationToken();
            await compositeValidator.ValidateAsync(obj, ct);

            await validator1.Received(1)
                            .ValidateAsync(obj, ct);

            await validator2.Received(1)
                            .ValidateAsync(obj, ct);
        }

        [Fact]
        public async Task ValidateCombinesResults()
        {
            var validator1 = Substitute.For<IValidator>();
            var error1 = new ValidationError("property", "error");

            validator1.ValidateAsync(Arg.Any<object>(), Arg.Any<CancellationToken>())
                      .Returns(new ValidationResult(new[] {error1}));

            var validator2 = Substitute.For<IValidator>();
            var error2 = new ValidationError("property", "error");

            validator2.ValidateAsync(Arg.Any<object>(), Arg.Any<CancellationToken>())
                      .Returns(new ValidationResult(new[] {error2}));

            var compositeValidator = new CompositeValidator(new []{validator1, validator2});

            var obj = "abc";
            ValidationResult result = await compositeValidator.ValidateAsync(obj, CancellationToken.None);

            result.Errors.Should()
                  .BeEquivalentTo(error1, error2);
        }
    }
}