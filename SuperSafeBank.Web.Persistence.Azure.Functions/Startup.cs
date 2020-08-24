using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SuperSafeBank.Core;
using SuperSafeBank.Domain.Events;
using SuperSafeBank.Web.Persistence.Azure.Functions;
using SuperSafeBank.Web.Persistence.Azure.Functions.EventHandlers;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SuperSafeBank.Web.Persistence.Azure.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IEventSerializer>(new JsonEventSerializer(new[]
            {
                typeof(CustomerCreated).Assembly
            }));

            builder.Services.AddMediatR(typeof(CustomersArchiveHandler));
        }
    }
}