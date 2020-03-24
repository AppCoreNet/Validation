AppCore .NET Validation
-----------------------

[![Build Status](https://dev.azure.com/AppCoreNet/Validation/_apis/build/status/AppCoreNet.Validation?branchName=dev)](https://dev.azure.com/AppCoreNet/Validation/_build/latest?definitionId=4&branchName=dev)

This repository contains model validation abstractions and implementations targeting the .NET Framework and .NET Core.

All artifacts are licensed under the [MIT license](LICENSE). You are free to use them in open-source or commercial projects as long
as you keep the copyright notice intact when redistributing or otherwise reusing our artifacts.

## Packages

Latest development packages can be found on [MyGet](https://www.myget.org/gallery/appcorenet).

Package                                           | Description
--------------------------------------------------|------------------------------------------------------------------------------------------------------
`AppCore.Validation`                            | Provides the default implementations agnostic to the actual validation framework.
`AppCore.Validation.Abstractions`              | Contains the public API of the model validation framework.
`AppCore.Validation.DataAnnotations`           | Integrates DataAnnotations with the validation framework.
`AppCore.Validation.FluentValidation`          | Integration of [FluentValidation](https://fluentvalidation.net/).
`AppCore.Validation.AspNetCore.Mvc`            | Provides filters for ASP.NET Core MVC.

### Validation

This packages includes the default implementations. To configure validation in your application, register the facility:

```
registry.RegisterFacility<ValidationFacility>();
```

### Abstractions

This packages includes the validation API for applications and providers.

### DataAnnotations

Adds support for using DataAnnotations.
To use DataAnnotations configure the provider when registering the facility:
```
registry.RegisterFacility<ValidationFacility>()
        .AddDataAnnotations();
```

### FluentValidation

Adds support for using FluentValidation.
To use FluentValidation, configure the provider and add validators when registering the facility:
```
registry.RegisterFacility<ValidationFacility>()
        .AddFluentValidation(v => v.UseValidators(r => r.Add<MyValidator>()));
```

## Contributing

Contributions, whether you file an issue, fix some bug or implement a new feature, are highly appreciated. The whole user community
will benefit from them.

Please refer to the [Contribution guide](CONTRIBUTING.md).
