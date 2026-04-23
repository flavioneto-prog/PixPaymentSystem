namespace PixPaymentSystem.Application.Interfaces
{
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Defines the contract for a service that handles Pix operations.
    /// </summary>
    public interface IPixService
    {
        /// <summary>
        /// Executes a Pix operation based on the specified type, value, and context.
        /// </summary>
        /// <param name="tipo">The type of the Pix operation.</param>
        /// <param name="valor">The monetary value of the Pix operation.</param>
        /// <param name="contexto">The context containing additional information for the Pix operation.</param>
        void Executar(TipoPix tipo, decimal valor, PixContexto contexto);
    }
}
