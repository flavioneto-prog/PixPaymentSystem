using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PixPaymentSystem.Tests.Integration.Base
{
    public abstract class IntegrationTestBase
    {
        protected readonly ServiceProvider Provider;

        protected IntegrationTestBase()
        {
            var services = new ServiceCollection();

            // Factories
            services.AddTransient<IPixFactory, PixImediatoFactory>();
            services.AddTransient<IPixFactory, PixAgendadoFactory>();
            services.AddTransient<IPixFactory, PixRecorrenteFactory>();

            // Core
            services.AddSingleton<IPixFactoryResolver, PixFactoryResolver>();
            IServiceCollection serviceCollection = services.AddTransient<IPixService, Application.Services.PixService>();

            Provider = services.BuildServiceProvider();
        }
    }
}
