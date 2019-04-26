// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.Validation.FluentValidation
{
    public class FluentValidationRegistrationTests
    {
        [Fact]
        public void AddFluentValidationRegistersProvider()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<ValidationFacility>()
                    .AddFluentValidation();

            registry.GetRegistrations()
                    .Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidatorProvider)
                            && cr.Lifetime == ComponentLifetime.Transient
                            && cr.Flags == ComponentRegistrationFlags.IfNotRegistered);
        }

        [Fact]
        public void UseValidatorsRegistersValidator()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<ValidationFacility>()
                    .AddFluentValidation()
                    .AddValidators(r => r.Add<TestModelValidator>());

            registry.GetRegistrations()
                    .Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidator<>)
                            && cr.Lifetime == ComponentLifetime.Transient);
        }
    }
}
