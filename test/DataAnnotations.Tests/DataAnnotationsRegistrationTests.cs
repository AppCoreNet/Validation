// Licensed under the MIT License.
// Copyright (c) 2018-2020 the AppCore .NET project.

using System.Collections.Generic;
using AppCore.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AppCore.ModelValidation.DataAnnotations
{
    public class DataAnnotationsRegistrationTests
    {
        private class ServiceCollection : List<ServiceDescriptor>, IServiceCollection
        {
        }

        [Fact]
        public void AddFluentValidationRegistersProvider()
        {
            var services = new ServiceCollection();
            services.AddModelValidation(v => v.UseDataAnnotations());

            services.Should()
                    .Contain(
                        sd =>
                            sd.ServiceType == typeof(IValidatorProvider)
                            && sd.ImplementationType == typeof(DataAnnotationsValidatorProvider)
                            && sd.Lifetime == ServiceLifetime.Transient);
        }
    }
}