// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;
using FV = FluentValidation;

namespace AppCore.ModelValidation.FluentValidation
{
    public class FluentValidationRegistrationTests
    {
        [Fact]
        public void AddFluentValidationRegistersProvider()
        {
            var registry = new TestComponentRegistry();

            registry.AddValidation(v => v.UseFluentValidation());

            registry.Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidatorProvider)
                            && cr.ImplementationType == typeof(FluentValidationValidatorProvider)
                            && cr.Lifetime == ComponentLifetime.Transient);
        }

        [Fact]
        public void AddValidatorRegistersValidator()
        {
            var registry = new TestComponentRegistry();

            registry.AddValidation(
                v =>
                    v.UseFluentValidation(
                        f => f
                            .WithValidator<TestModelValidator>()));

            registry.Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(FV.IValidator<TestModel>)
                            && cr.Lifetime == ComponentLifetime.Transient);
        }

        [Fact]
        public void AddValidatorsRegistersValidator()
        {
            var registry = new TestComponentRegistry();

            registry.AddValidation(
                v =>
                    v.UseFluentValidation(
                        f => f
                            .WithValidatorsFrom(
                                s => s.Assemblies(
                                    a => a
                                         .ClearDefaultFilters()
                                         .From(typeof(TestModelValidator).Assembly))
                            )
                    ));

            registry.Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(FV.IValidator<TestModel>)
                            && cr.Lifetime == ComponentLifetime.Transient);
        }
    }
}
