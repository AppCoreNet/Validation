// Licensed under the MIT License.
// Copyright (c) 2018-2022 the AppCore .NET project.

using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace AppCore.Extensions.DependencyInjection
{
    /// <summary>
    /// FluentValidation builder.
    /// </summary>
    public interface IFluentValidationBuilder
    {
        /// <summary>
        /// The <see cref="IServiceCollection"/>.
        /// </summary>
        IServiceCollection Services { get; }
    }
}