// Licensed under the MIT License.
// Copyright (c) 2020-2021 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AppCore.ModelValidation
{
    /// <summary>
    /// Represents the validation facility.
    /// </summary>
    public sealed class ModelValidationFacility : Facility
    {
        /// <inheritdoc />
        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.TryAddTransient<IValidatorFactory, ValidatorFactory>();
            services.TryAddTransient(typeof(IValidator<>), typeof(Validator<>));
        }
    }
}