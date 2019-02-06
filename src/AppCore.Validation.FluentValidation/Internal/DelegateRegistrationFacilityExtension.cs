// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.DependencyInjection.Builder;
using AppCore.DependencyInjection.Facilities;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    internal class DelegateRegistrationFacilityExtension : FacilityExtension<IValidationFacility>
    {
        private readonly Type _contractType;
        private readonly Action<IRegistrationBuilder, IValidationFacility> _action;

        public DelegateRegistrationFacilityExtension(Type contractType, Action<IRegistrationBuilder, IValidationFacility> action)
        {
            _contractType = contractType;
            _action = action;
        }

        protected override void RegisterComponents(IComponentRegistry registry, IValidationFacility facility)
        {
            _action(registry.Register(_contractType), facility);
        }
    }
}