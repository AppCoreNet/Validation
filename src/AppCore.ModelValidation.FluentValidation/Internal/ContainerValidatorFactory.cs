// Licensed under the MIT License.
// Copyright (c) 2018-2020 the AppCore .NET project.

using System;
using FluentValidation;
using FV = FluentValidation;

// ReSharper disable once CheckNamespace
namespace AppCore.ModelValidation.FluentValidation
{
    internal sealed class ContainerValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _container;

        public ContainerValidatorFactory(IServiceProvider container)
        {
            _container = container;
        }

        public override FV.IValidator CreateInstance(Type validatorType)
        {
            return _container.GetService(validatorType) as FV.IValidator;
        }
    }
}