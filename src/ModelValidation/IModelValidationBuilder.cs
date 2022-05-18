// Licensed under the MIT License.
// Copyright (c) 2018-2022 the AppCore .NET project.

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Model validation builder.
    /// </summary>
    public interface IModelValidationBuilder
    {
        /// <summary>
        /// The <see cref="IServiceCollection"/>.
        /// </summary>
        IServiceCollection Services { get; }
    }
}