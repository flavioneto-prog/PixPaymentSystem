using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Application.Services;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix;
using Microsoft.Extensions.DependencyInjection;
using PixPaymentSystem.Domain.Pix.Validators;
using PixPaymentSystem.Application.Pipelines.Chains;

var services = new ServiceCollection();

services.AddTransient<IPixFactory, PixImediatoFactory>();
services.AddTransient<IPixFactory, PixAgendadoFactory>();
services.AddTransient<IPixFactory, PixRecorrenteFactory>();

services.AddSingleton<IPixFactoryResolver, PixFactoryResolver>();

services.AddTransient<IPixValidatorChain, PixValidatorChain>();

// A ordem do DI define a ordem da chain
services.AddTransient<PixValidationHandler, ValorNegativoValidator>();
services.AddTransient<PixValidationHandler, LimiteValidator>();

services.AddTransient<IPixService, PixService>();

var provider = services.BuildServiceProvider();
var pixService = provider.GetRequiredService<IPixService>();

// Pix Imediato — sem dados extras
pixService.Executar(TipoPix.Imediato, 250.00m, new PixContexto());

// Pix Agendado — requer data futura
pixService.Executar(TipoPix.Agendado, 500.00m, new PixContexto(
    DataAgendamento: DateTime.UtcNow.AddDays(3)
));

// Pix Recorrente — requer frequência e data fim
pixService.Executar(TipoPix.Recorrente, 100.00m, new PixContexto(
    FrequenciaDias: 30,
    DataFim: DateTime.UtcNow.AddMonths(6)
));