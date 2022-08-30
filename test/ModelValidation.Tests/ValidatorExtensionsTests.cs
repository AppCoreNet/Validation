// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AppCore.ModelValidation;

public class ValidatorExtensionsTests
{
    [Fact]
    public async Task ValidatesOfTAndThrowsIfNotValid()
    {
        var validator = Substitute.For<IValidator<string>>();
        validator.ValidateAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
                 .Returns(ValidationResultFactory.Create());

        Func<Task> test = () => validator
                                .ValidateAndThrowAsync("abc", ValidationErrorSeverity.Error, CancellationToken.None)
                                .AsTask();
        await test.Should()
                  .ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ValidatesAndThrowsIfNotValid()
    {
        var validator = Substitute.For<IValidator>();
        validator.ValidateAsync(Arg.Any<object>(), Arg.Any<CancellationToken>())
                 .Returns(ValidationResultFactory.Create());

        Func<Task> test = () => validator
                                .ValidateAndThrowAsync("abc", ValidationErrorSeverity.Error, CancellationToken.None)
                                .AsTask();
        await test.Should()
                  .ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task ValidatesOfTAndDoesNotThrowIfValid()
    {
        var validator = Substitute.For<IValidator<string>>();
        validator.ValidateAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
                 .Returns(ValidationResultFactory.Create(ValidationErrorSeverity.Info));

        Func<Task> test = () => validator
                                .ValidateAndThrowAsync("abc", ValidationErrorSeverity.Error, CancellationToken.None)
                                .AsTask();
        await test.Should()
                  .NotThrowAsync();
    }

    [Fact]
    public async Task ValidatesAndDoesNotThrowIfValid()
    {
        var validator = Substitute.For<IValidator>();
        validator.ValidateAsync(Arg.Any<object>(), Arg.Any<CancellationToken>())
                 .Returns(ValidationResultFactory.Create(ValidationErrorSeverity.Info));

        Func<Task> test = () => validator
                                .ValidateAndThrowAsync("abc", ValidationErrorSeverity.Error, CancellationToken.None)
                                .AsTask();
        await test.Should()
                  .NotThrowAsync();
    }
}