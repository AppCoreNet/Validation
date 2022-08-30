// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System;
using System.Collections.Generic;
using System.Linq;
using AppCore.Diagnostics;

namespace AppCore.ModelValidation;

/// <summary>
/// Provides default implementation of <see cref="IValidatorFactory"/>.
/// </summary>
public sealed class ValidatorFactory : IValidatorFactory
{
    private readonly IEnumerable<IValidatorProvider> _providers;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidatorFactory"/> class.
    /// </summary>
    /// <param name="providers">The <see cref="IEnumerable{T}"/> of <see cref="IValidatorProvider"/>.</param>
    /// <exception cref="ArgumentNullException">Argument <paramref name="providers"/> must not be <c>null</c>.</exception>
    public ValidatorFactory(IEnumerable<IValidatorProvider> providers)
    {
        Ensure.Arg.NotNull(providers);
        _providers = providers;
    }

    /// <inheritdoc />
    public IValidator CreateValidator(Type modelType)
    {
        Ensure.Arg.NotNull(modelType);
        IEnumerable<IValidator> validators = _providers.Select(p => p.CreateValidator(modelType));
        return new CompositeValidator(validators.ToArray());
    }
}