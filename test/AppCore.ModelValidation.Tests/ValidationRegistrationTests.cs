// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.ModelValidation
{
    public class ValidationRegistrationTests
    {
        [Fact]
        public void RegisterValidationFacilityRegistersComponents()
        {
            var registry = new TestComponentRegistry();
            registry.AddModelValidation();

            registry
                    .Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidatorFactory)
                            && cr.ImplementationType == typeof(ValidatorFactory)
                            && cr.Lifetime == ComponentLifetime.Transient);

            registry
                .Should()
                .Contain(
                    cr =>
                        cr.ContractType == typeof(IValidator<>)
                        && cr.ImplementationType == typeof(Validator<>)
                        && cr.Lifetime == ComponentLifetime.Transient);
        }
    }
}