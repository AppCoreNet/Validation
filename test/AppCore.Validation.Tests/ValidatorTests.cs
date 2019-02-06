// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace AppCore.Validation
{
    public class ValidatorTests
    {
        [Fact]
        public void CtorCreatesValidatorWithSpecifiedType()
        {
            var factory = Substitute.For<IValidatorFactory>();

            Type objType = typeof(string);
            var validator = new Validator<string>(factory);

            factory.Received(1)
                   .CreateValidator(objType);
        }

        [Fact]
        public async Task ValidateInvokesInnerValidator()
        {
            var innerValidator = Substitute.For<IValidator>();

            var factory = Substitute.For<IValidatorFactory>();
            factory.CreateValidator(Arg.Any<Type>())
                   .Returns(innerValidator);

            var validator = new Validator<string>(factory);
            var obj = "abc";
            var cancellationToken = new CancellationToken();

            await validator.ValidateAsync(obj, cancellationToken);

            await innerValidator.Received(1)
                                .ValidateAsync(obj, cancellationToken);
        }
    }
}
