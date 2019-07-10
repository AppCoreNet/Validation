// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;
using FV = FluentValidation;

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
                            && cr.ImplementationType == typeof(FluentValidationValidatorProvider)
                            && cr.Lifetime == ComponentLifetime.Transient
                            && cr.Flags == ComponentRegistrationFlags.IfNotRegistered);
        }

        [Fact]
        public void AddValidatorsRegistersValidator()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<ValidationFacility>()
                    .AddFluentValidation(
                        fv => fv.AddValidators(
                            r => r.Add<TestModelValidator>()));

            registry.GetRegistrations()
                    .Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(FV.IValidator<>)
                            && cr.Lifetime == ComponentLifetime.Transient);
        }
    }
}
