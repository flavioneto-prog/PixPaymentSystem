using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PixPaymentSystem.Application.Pipelines.Chains;
using PixPaymentSystem.Domain.Pix.Validators;

namespace PixPaymentSystem.Tests.Integration.Base
{
    public abstract class IntegrationTestBase
    {
        protected readonly ServiceProvider Provider;

        protected IntegrationTestBase()
        {
            var services = new ServiceCollection();

            // Logging
            services.AddLogging();

            // Factories
            services.AddTransient<IPixFactory, PixImediatoFactory>();
            services.AddTransient<IPixFactory, PixAgendadoFactory>();
            services.AddTransient<IPixFactory, PixRecorrenteFactory>();

            // Chain Validator
            services.AddTransient<IPixValidatorChain, PixValidatorChain>();
            services.AddTransient<PixValidationHandler, ValorNegativoValidator>();
            services.AddTransient<PixValidationHandler, LimiteValidator>();

            // Core
            services.AddSingleton<IPixFactoryResolver, PixFactoryResolver>();
            services.AddTransient<IPixService, Application.Services.PixService>();

            Provider = services.BuildServiceProvider();
        }
    }
}
