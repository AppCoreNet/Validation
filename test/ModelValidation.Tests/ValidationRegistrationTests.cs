// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AppCore.ModelValidation
{
    public class ValidationRegistrationTests
    {
        private class ServiceCollection : List<ServiceDescriptor>, IServiceCollection
        {
        }

        [Fact]
        public void RegisterValidationFacilityRegistersComponents()
        {
            var services = new ServiceCollection();
            services.AddModelValidation();

            services
                    .Should()
                    .Contain(
                        sd =>
                            sd.ServiceType == typeof(IValidatorFactory)
                            && sd.ImplementationType == typeof(ValidatorFactory)
                            && sd.Lifetime == ServiceLifetime.Transient);

            services
                .Should()
                .Contain(
                    sd =>
                        sd.ServiceType == typeof(IValidator<>)
                        && sd.ImplementationType == typeof(Validator<>)
                        && sd.Lifetime == ServiceLifetime.Transient);
        }
    }
}