// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.Validation.DataAnnotations
{
    public class DataAnnotationsRegistrationTests
    {
        [Fact]
        public void AddFluentValidationRegistersProvider()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<ValidationFacility>()
                    .AddDataAnnotations();

            registry.GetRegistrations()
                    .Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidatorProvider)
                            && cr.Lifetime == ComponentLifetime.Transient
                            && cr.Flags == ComponentRegistrationFlags.IfNotRegistered);
        }
    }
}