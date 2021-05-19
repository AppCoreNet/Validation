// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System.Threading;
using System.Threading.Tasks;

namespace AppCore.Validation.FluentValidation
{
    internal class NullValidator : IValidator
    {
        public static readonly NullValidator Instance = new NullValidator();

        public ValueTask<ValidationResult> ValidateAsync(object model, CancellationToken cancellationToken = default)
        {
            return new ValueTask<ValidationResult>(ValidationResult.Success);
        }
    }
}