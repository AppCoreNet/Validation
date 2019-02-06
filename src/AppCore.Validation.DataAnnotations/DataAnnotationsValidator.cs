// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppCore.Diagnostics;

namespace AppCore.Validation.DataAnnotations
{
    /// <summary>
    /// Provides a <see cref="IValidator"/> which uses the <see cref="System.ComponentModel.DataAnnotations"/>.
    /// </summary>
    public class DataAnnotationsValidator : IValidator
    {
        #if NETSTANDARD1_1

        private ValidationContext CreateValidationContext(object model, IDictionary<object, object> items)
        {
            return new ValidationContext(model, items);
        }

        #else

        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAnnotationsValidator"/> class.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to initialize the <see cref="ValidationContext"/>.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="serviceProvider"/> must not be <c>null</c>.</exception>
        public DataAnnotationsValidator(IServiceProvider serviceProvider)
        {
            Ensure.Arg.NotNull(serviceProvider, nameof(serviceProvider));
            _serviceProvider = serviceProvider;
        }

        private ValidationContext CreateValidationContext(object obj, IDictionary<object, object> items)
        {
            return new ValidationContext(obj, _serviceProvider, items);
        }

        #endif

        /// <inheritdoc />
        public ValueTask<ValidationResult> ValidateAsync(object model, CancellationToken cancellationToken)
        {
            ValidationContext context = CreateValidationContext(model, null);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (!Validator.TryValidateObject(model, context, results))
            {
                IEnumerable<ValidationError> errors = results.SelectMany(
                    r => r.MemberNames.Select(m => new ValidationError(m, r.ErrorMessage)));

                return new ValueTask<ValidationResult>(new ValidationResult(errors));
            }

            return new ValueTask<ValidationResult>(ValidationResult.Success);
        }
    }
}
