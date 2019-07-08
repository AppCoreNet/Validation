// Licensed under the MIT License.
// Copyright (c) 2018,2019 the AppCore .NET project.

using System;
using AppCore.DependencyInjection;
using FluentValidation;
using FV = FluentValidation;

namespace AppCore.Validation.FluentValidation
{
    internal sealed class ContainerValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;

        public ContainerValidatorFactory(IContainer container)
        {
            _container = container;
        }

        public override FV.IValidator CreateInstance(Type validatorType)
        {
            return _container.ResolveOptional(validatorType) as FV.IValidator;
        }
    }
}