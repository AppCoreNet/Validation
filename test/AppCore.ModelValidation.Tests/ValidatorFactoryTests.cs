// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using NSubstitute;
using Xunit;

namespace AppCore.Validation
{
    public class ValidatorFactoryTests
    {
        [Fact]
        public void CreateResolvesValidatorFromProviders()
        {
            var provider1 = Substitute.For<IValidatorProvider>();
            var provider2 = Substitute.For<IValidatorProvider>();

            var factory = new ValidatorFactory(new[] {provider1, provider2});

            Type objType = typeof(string);
            IValidator validator = factory.CreateValidator(objType);

            provider1.Received(1)
                     .CreateValidator(objType);

            provider2.Received(1)
                     .CreateValidator(objType);
        }
    }
}
