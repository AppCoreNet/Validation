// Licensed under the MIT License.
// Copyright (c) 2018-2020 the AppCore .NET project.

using System.Collections.Generic;
using AppCore.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AppCore.ModelValidation.DataAnnotations;

public class DataAnnotationsRegistrationTests
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
                .AddModelValidation(v => v.AddDataAnnotations());

        services.Should()
                .Contain(
                    sd =>
                        sd.ServiceType == typeof(IValidatorProvider)
                        && sd.ImplementationType == typeof(DataAnnotationsValidatorProvider)
                        && sd.Lifetime == ServiceLifetime.Transient);
    }
}