// Licensed under the MIT License.
// Copyright (c) 2018-2020 the AppCore .NET project.

using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.ModelValidation.DataAnnotations
{
    public class DataAnnotationsRegistrationTests
    {
        [Fact]
        public void AddFluentValidationRegistersProvider()
        {
            var registry = new TestComponentRegistry();
            registry.AddModelValidation(v => v.UseDataAnnotations());

            registry.Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidatorProvider)
                            && cr.ImplementationType == typeof(DataAnnotationsValidatorProvider)
                            && cr.Lifetime == ComponentLifetime.Transient);
        }
    }
}