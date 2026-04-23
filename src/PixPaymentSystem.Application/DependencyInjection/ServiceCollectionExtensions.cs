using Microsoft.Extensions.DependencyInjection;
using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Application.Pipelines.Chains;
using PixPaymentSystem.Application.Resolvers;
using PixPaymentSystem.Application.Services;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Processing;
using PixPaymentSystem.Domain.Pix.Resolvers;
using PixPaymentSystem.Domain.Pix.Validators;

namespace PixPaymentSystem.Application.DependencyInjection;

/// <summary>
/// Classe responsável pelo DI
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Injeção de dependência necessária para utilização da aplicação por completo.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddLogging();

        services.AddScoped<IPixProcessingStrategy, PixQrCodeEstaticoStrategy>();
        services.AddScoped<IPixProcessingStrategy, PixQrCodeDinamicoStrategy>();
        services.AddScoped<IPixProcessingStrategy, PixCopiaEColaStrategy>();
        services.AddScoped<IPixProcessingStrategy, PixChaveStrategy>();

        services.AddScoped<PixProcessingStrategyResolver>();

        services.AddTransient<IPixFactory, PixImediatoFactory>();
        services.AddTransient<IPixFactory, PixAgendadoFactory>();
        services.AddTransient<IPixFactory, PixRecorrenteFactory>();

        services.AddSingleton<IPixFactoryResolver, PixFactoryResolver>();

        services.AddTransient<IPixValidatorChain, PixValidatorChain>();

        // A ordem do DI define a ordem da chain
        services.AddTransient<PixValidationHandler, ValorNegativoValidator>();
        services.AddTransient<PixValidationHandler, LimiteValidator>();

        services.AddTransient<IIdempotencyService, IdempotencyService>();
        services.AddTransient<IPixService, PixService>();

        return services;
    }
}
