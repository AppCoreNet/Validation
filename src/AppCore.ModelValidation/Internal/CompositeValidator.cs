// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppCore.Diagnostics;

namespace AppCore.Validation
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