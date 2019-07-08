// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System;
using System.Collections.Generic;
using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Builder;
using AppCore.DependencyInjection.Facilities;
using FV = FluentValidation;

namespace AppCore.Validation.FluentValidation
{
    /// <summary>
    /// Provides a extensions for the <see cref="IValidationFacility"/> which adds validation using FluentValidation.
    /// </summary>
    public sealed class FluentValidationExtension : FacilityExtension<IValidationFacility>
    {
        private readonly List<Action<IRegistrationBuilder<FV.IValidator>, IValidationFacility>> _registrationActions =
            new List<Action<IRegistrationBuilder<FV.IValidator>, IValidationFacility>>();

        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry, IValidationFacility facility)
        {
            registry.Register<IValidatorProvider>()
                    .Add<FluentValidationValidatorProvider>()
                    .PerDependency()
                    .IfNotRegistered();

            registry.Register<FV.IValidatorFactory>()
                    .Add<ContainerValidatorFactory>()
                    .PerDependency()
                    .IfNoneRegistered();

            IRegistrationBuilder<FV.IValidator> validatorRegistrationBuilder = registry.Register<FV.IValidator>();
            foreach (Action<IRegistrationBuilder<FV.IValidator>, IValidationFacility> registrationAction in _registrationActions)
            {
                registrationAction(validatorRegistrationBuilder, facility);
            }
        }

        public void RegisterValidators(Action<IRegistrationBuilder<FV.IValidator>, IValidationFacility> registrationBuilder)
        {
            _registrationActions.Add(registrationBuilder);
        }
    }
}