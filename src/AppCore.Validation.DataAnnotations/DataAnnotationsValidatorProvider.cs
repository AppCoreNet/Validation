// Licensed under the MIT License.
// Copyright (c) 2018-2020 the AppCore .NET project.

using System;
using System.ComponentModel.DataAnnotations;
using AppCore.Diagnostics;

namespace AppCore.Validation.DataAnnotations
{
    /// <summary>
    /// Provides a <see cref="IValidatorProvider"/> which creates <see cref="DataAnnotationsValidator"/> instances.
    /// </summary>
    public sealed class DataAnnotationsValidatorProvider : IValidatorProvider
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAnnotationsValidatorProvider"/> class.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used for the <see cref="ValidationContext"/>.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="serviceProvider"/> must not be <c>null</c>.</exception>
        public DataAnnotationsValidatorProvider(IServiceProvider serviceProvider)
        {
            Ensure.Arg.NotNull(serviceProvider, nameof(serviceProvider));
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public IValidator CreateValidator(Type modelType)
        {
            return new DataAnnotationsValidator(_serviceProvider);
        }
    }
}
