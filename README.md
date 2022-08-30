AppCore .NET Validation
-----------------------

[![Build Status](https://dev.azure.com/AppCoreNet/ModelValidation/_apis/build/status/AppCoreNet.ModelValidation%20CI?branchName=dev)](https://dev.azure.com/AppCoreNet/ModelValidation/_build/latest?definitionId=4&branchName=dev)
![Azure DevOps tests (compact)](https://img.shields.io/azure-devops/tests/AppCoreNet/ModelValidation/4?compact_message)
![Azure DevOps coverage (branch)](https://img.shields.io/azure-devops/coverage/AppCoreNet/ModelValidation/4/dev)
![Nuget](https://img.shields.io/nuget/v/AppCore.ModelValidation.Abstractions)

This repository contains abstractions and implementations for model validation. It targets the .NET Framework and .NET Core.

All artifacts are licensed under the [MIT license](LICENSE). You are free to use them in open-source or commercial projects as long
as you keep the copyright notice intact when redistributing or otherwise reusing our artifacts.

## Packages

Latest development packages can be found on [MyGet](https://www.myget.org/gallery/appcorenet).

Package                                           | Description
--------------------------------------------------|------------------------------------------------------------------------------------------------------
`AppCore.ModelValidation`                         | Provides the default implementations agnostic to the actual validation framework.
`AppCore.ModelValidation.Abstractions`            | Contains the public API of the model validation framework.
`AppCore.ModelValidation.DataAnnotations`         | Integrates DataAnnotations with the validation framework.
`AppCore.ModelValidation.FluentValidation`        | Integration of [FluentValidation](https://fluentvalidation.net/).
`AppCore.ModelValidation.AspNetCore.Mvc`          | Provides filters for ASP.NET Core MVC.

### Validation

This packages includes the default implementations. To configure validation in your application, register the facility:

```
services.AddAppCore()
        .AddModelValidation();
```

### Abstractions

This packages includes the validation API for applications and providers.

### DataAnnotations

Adds support for using DataAnnotations.
To use DataAnnotations configure the provider when registering the facility:
```
services.AddAppCore()
        .AddModelValidation(v => v.AddDataAnnotations());
```

### FluentValidation

Adds support for using FluentValidation.
To use FluentValidation, configure the provider and add validators when registering the facility:
```
services.AddAppCore()
        .AddModelValidation(v => v.AddFluentValidation(fv => fv.AddValidator<MyValidator>())));
```

## Contributing

Contributions, whether you file an issue, fix some bug or implement a new feature, are highly appreciated. The whole user community
will benefit from them.

Please refer to the [Contribution guide](CONTRIBUTING.md).
