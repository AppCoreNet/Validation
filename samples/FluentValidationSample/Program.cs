using System;
using System.Threading;
using System.Threading.Tasks;
using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Microsoft.Extensions;
using AppCore.ModelValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FluentValidationSample
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            var registry = new MicrosoftComponentRegistry(services);
            registry.AddModelValidation(
                v => v.UseFluentValidation(fv => fv.WithValidator<PersonValidator>()));

            ServiceProvider sp = services.BuildServiceProvider();
            var validator = sp.GetRequiredService<IValidator<Person>>();
            await validator.ValidateAsync(new Person(), CancellationToken.None);

            Console.WriteLine("Hello World!");
        }
    }
}
