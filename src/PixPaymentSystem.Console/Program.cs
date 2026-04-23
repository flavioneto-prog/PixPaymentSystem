namespace PixPaymentSystem.Console
{
    using Microsoft.Extensions.DependencyInjection;
    using PixPaymentSystem.Application.Interfaces;
    using PixPaymentSystem.Application.DependencyInjection;
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Pix;

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
            pixService.Executar(TipoPix.Imediato, 250.00m, new PixContexto());

            // Pix Agendado — requer data futura
            pixService.Executar(TipoPix.Agendado, 500.00m, new PixContexto(DataAgendamento: DateTime.UtcNow.AddDays(3)));

            // Pix Recorrente — requer frequência e data fim
            pixService.Executar(TipoPix.Recorrente, 100.00m, new PixContexto(FrequenciaDias: 30, DataFim: DateTime.UtcNow.AddMonths(6)));
        }
    }
}