// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System.Collections.Generic;
using AppCore.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FV = FluentValidation;

namespace AppCore.ModelValidation.FluentValidation
{
    public class FluentValidationRegistrationTests
    {
        #nullable disable
        private class ServiceCollection : List<ServiceDescriptor>, IServiceCollection
        {
        }
        #nullable restore

        [Fact]
        public void AddFluentValidationRegistersProvider()
        {
            var services = new ServiceCollection();

            services.AddAppCore()
                    .AddModelValidation(v => v.AddFluentValidation());

            services.Should()
                    .Contain(
                        sd =>
                            sd.ServiceType == typeof(IValidatorProvider)
                            && sd.ImplementationType == typeof(FluentValidationValidatorProvider)
                            && sd.Lifetime == ServiceLifetime.Transient);
        }

        [Fact]
        public void AddValidatorRegistersValidator()
        {
            var services = new ServiceCollection();

            services.AddAppCore()
                    .AddModelValidation(
                        v =>
                        {
                            v.AddFluentValidation()
                             .AddValidator<TestModelValidator>();
                        });

            services.Should()
                    .Contain(
                        sd =>
                            sd.ServiceType == typeof(FV.IValidator<TestModel>)
                            && sd.Lifetime == ServiceLifetime.Transient);
        }

        [Fact]
        public void AddValidatorsRegistersValidator()
        {
            var services = new ServiceCollection();

            services.AddAppCore()
                    .AddModelValidation(
                        v =>
                        {
                            v.AddFluentValidation()
                             .AddValidatorsFrom(
                                 s => s.Assemblies(
                                     a => a
                                          .ClearDefaultFilters()
                                          .Add(typeof(TestModelValidator).Assembly))
                             );
                        });

            services.Should()
                    .Contain(
                        sd =>
                            sd.ServiceType == typeof(FV.IValidator<TestModel>)
                            && sd.Lifetime == ServiceLifetime.Transient);
        }
    }
}
