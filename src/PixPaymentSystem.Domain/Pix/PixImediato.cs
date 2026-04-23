namespace PixPaymentSystem.Domain.Pix
{
    using PixPaymentSystem.Domain.Interfaces;

    /// <summary>
    /// Represents an immediate Pix transaction.
    /// </summary>
    public sealed class PixImediato : ITransacaoPix
    {
        /// <summary>
        /// Processes the immediate Pix transaction with the specified value.
        /// </summary>
        /// <param name="valor">The value of the transaction.</param>
        public void Processar(decimal valor)
        {
            Console.WriteLine($"Pix Imediato de R$ {valor} processado em {DateTime.UtcNow:dd/MM/yyyy HH:mm:ss}");
        }
    }
}
