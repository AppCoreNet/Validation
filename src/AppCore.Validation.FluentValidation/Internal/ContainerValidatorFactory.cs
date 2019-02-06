// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.DependencyInjection;
using FluentValidation;

namespace AppCore.Validation
{
    internal sealed class ContainerValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;

        public ContainerValidatorFactory(IContainer container)
        {
            _container = container;
        }

        public override FluentValidation.IValidator CreateInstance(Type validatorType)
        {
            return _container.ResolveOptional(validatorType) as FluentValidation.IValidator;
        }
    }
}