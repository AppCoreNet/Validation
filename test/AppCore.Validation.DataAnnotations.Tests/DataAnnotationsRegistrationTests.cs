// Licensed under the MIT License.
// Copyright (c) 2018-2020 the AppCore .NET project.

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
            registry.AddFacility<ValidationFacility>(v => v.UseDataAnnotations());

            registry.Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidatorProvider)
                            && cr.ImplementationType == typeof(DataAnnotationsValidatorProvider)
                            && cr.Lifetime == ComponentLifetime.Transient);
        }
    }
}