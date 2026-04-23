using Microsoft.Extensions.DependencyInjection;
using PixPaymentSystem.Application.DependencyInjection;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Pix.Agendado;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Imediato;
using PixPaymentSystem.Domain.Pix.Recorrente;

namespace PixPaymentSystem.Console
{
    /// <summary>
    /// Entry point for the Pix Payment System application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Main method to configure services and execute Pix operations.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddApplication();

            var provider = services.BuildServiceProvider();
            var pixService = provider.GetRequiredService<IPixService>();

            // Pix Imediato — sem dados extras
            pixService.Executar(TipoPix.Imediato, new PixImediatoContexto(FormaProcessamentoPix.Chave, 250.00m, "chave@email.com"));

            // Pix Agendado — requer data futura
            pixService.Executar(TipoPix.Agendado, new PixAgendadoContexto(FormaProcessamentoPix.CopiaECola, 500.00m, "chave@email.com", DateTime.UtcNow.AddDays(3)));

            // Pix Recorrente — requer frequência e data fim
            pixService.Executar(TipoPix.Recorrente, new PixRecorrenteContexto(FormaProcessamentoPix.QrCodeDinamico, 100.00m, "chave@email.com", 30, DateTime.UtcNow.AddMonths(6)));
        }
    }
}