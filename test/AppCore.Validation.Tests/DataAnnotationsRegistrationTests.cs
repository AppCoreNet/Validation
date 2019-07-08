// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System.Collections.Generic;
using System.Linq;
using AppCore.DependencyInjection;
using FluentAssertions;
using Xunit;

namespace AppCore.Validation
{
    public class ValidationRegistrationTests
    {
        [Fact]
        public void RegisterValidationFacilityRegistersComponents()
        {
            var registry = new TestComponentRegistry();

            registry.RegisterFacility<ValidationFacility>();

            IEnumerable<ComponentRegistration> componentRegistrations = registry.GetRegistrations()
                                                                                .ToList();

            componentRegistrations
                    .Should()
                    .Contain(
                        cr =>
                            cr.ContractType == typeof(IValidatorFactory)
                            && cr.ImplementationType == typeof(ValidatorFactory)
                            && cr.Lifetime == ComponentLifetime.Transient
                            && cr.Flags == ComponentRegistrationFlags.IfNoneRegistered);

            componentRegistrations
                .Should()
                .Contain(
                    cr =>
                        cr.ContractType == typeof(IValidator<>)
                        && cr.ImplementationType == typeof(Validator<>)
                        && cr.Lifetime == ComponentLifetime.Transient
                        && cr.Flags == ComponentRegistrationFlags.IfNoneRegistered);
        }
    }
}