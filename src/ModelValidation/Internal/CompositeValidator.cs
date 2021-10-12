// Licensed under the MIT License.
// Copyright (c) 2018-2021 the AppCore .NET project.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppCore.Diagnostics;

// ReSharper disable once CheckNamespace
namespace AppCore.ModelValidation
{
    internal sealed class CompositeValidator : IValidator
    {
        private readonly IEnumerable<IValidator> _validators;

        public CompositeValidator(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }

        public async ValueTask<ValidationResult> ValidateAsync(object model, CancellationToken cancellationToken)
        {
            Ensure.Arg.NotNull(model, nameof(model));

            var results = new List<ValidationResult>();
            foreach (IValidator validator in _validators)
            {
                ValidationResult result = await validator.ValidateAsync(model, cancellationToken);
                results.Add(result);
            }

            return new ValidationResult(results.SelectMany(r => r.Errors));
        }
    }
}