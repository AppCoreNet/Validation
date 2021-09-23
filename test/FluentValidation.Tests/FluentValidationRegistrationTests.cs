// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System.Collections.Generic;
using AppCore.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FV = FluentValidation;

namespace AppCore.ModelValidation.FluentValidation
{
    public class FluentValidationRegistrationTests
    {
        private class ServiceCollection : List<ServiceDescriptor>, IServiceCollection
        {
        }

        [Fact]
        public void AddFluentValidationRegistersProvider()
        {
            var services = new ServiceCollection();

            services.AddAppCore().AddModelValidation(v => v.UseFluentValidation());

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

            services.AddAppCore().AddModelValidation(
                v =>
                    v.UseFluentValidation(
                        f => f
                            .WithValidator<TestModelValidator>()));

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

            services.AddAppCore().AddModelValidation(
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

            services.Should()
                    .Contain(
                        sd =>
                            sd.ServiceType == typeof(FV.IValidator<TestModel>)
                            && sd.Lifetime == ServiceLifetime.Transient);
        }
    }
}
