using PixPaymentSystem.Domain.Interfaces;

namespace PixPaymentSystem.Domain.Pix
{
    public sealed class PixImediato : ITransacaoPix
    {
        public void Processar(decimal valor)
        {
            Console.WriteLine($"Pix Imediato de R$ {valor} processado em {DateTime.UtcNow:dd/MM/yyyy HH:mm:ss}");
        }
    }
}
