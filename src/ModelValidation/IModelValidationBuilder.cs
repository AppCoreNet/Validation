// Licensed under the MIT License.
// Copyright (c) 2018-2022 the AppCore .NET project.

using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace AppCore.Extensions.DependencyInjection;

/// <summary>
/// Model validation builder.
/// </summary>
public interface IModelValidationBuilder
{
    /// <summary>
    /// The <see cref="IServiceCollection"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    IServiceCollection Services { get; }
}