// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System;
using System.Collections.Generic;
using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Builder;
using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using FV = FluentValidation;

namespace AppCore.Validation.FluentValidation
{
    /// <summary>
    /// Provides a extensions for the <see cref="IValidationFacility"/> which adds validation using FluentValidation.
    /// </summary>
    public sealed class FluentValidationExtension : FacilityExtension<IValidationFacility>
    {
        private readonly List<Action<IRegistrationBuilder, IValidationFacility>> _registrationActions =
            new List<Action<IRegistrationBuilder, IValidationFacility>>();

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

            IRegistrationBuilder validatorRegistrationBuilder = registry.Register(typeof(FV.IValidator<>));
            foreach (Action<IRegistrationBuilder, IValidationFacility> registrationAction in _registrationActions)
            {
                registrationAction(validatorRegistrationBuilder, facility);
            }
        }

        /// <summary>
        /// Registers components for the <see cref="FV.IValidator{T}"/> type.
        /// </summary>
        /// <param name="registration"></param>
        public void RegisterValidator(Action<IRegistrationBuilder, IValidationFacility> registration)
        {
            Ensure.Arg.NotNull(registration, nameof(registration));
            _registrationActions.Add(registration);
        }
    }
}