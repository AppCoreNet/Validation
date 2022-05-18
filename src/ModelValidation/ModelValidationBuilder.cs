// Licensed under the MIT License.
// Copyright (c) 2018-2022 the AppCore .NET project.

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    internal sealed class ModelValidationBuilder : IModelValidationBuilder
    {
        public IServiceCollection Services { get; }

        public ModelValidationBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}