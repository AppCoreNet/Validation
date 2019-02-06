using System;
using System.Threading;
using System.Threading.Tasks;
using AppCore.DependencyInjection;
using AppCore.Validation;
using AppCore.DependencyInjection.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FluentValidationSample
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddFacility<ValidationFacility>(
                f => f.UseFluentValidation(r => r.AddFromDependencyContext()));

            ServiceProvider sp = services.BuildServiceProvider();
            var validator = sp.GetRequiredService<IValidator<Person>>();
            await validator.ValidateAsync(new Person(), CancellationToken.None);

            Console.WriteLine("Hello World!");
        }
    }
}
