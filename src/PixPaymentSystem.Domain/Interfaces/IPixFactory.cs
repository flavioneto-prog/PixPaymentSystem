namespace PixPaymentSystem.Domain.Interfaces
{
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Represents a factory for creating Pix transactions.
    /// </summary>
    public interface IPixFactory
    {
        /// <summary>
        /// Gets the type of Pix transaction this factory handles.
        /// </summary>
        TipoPix Tipo { get; }

        /// <summary>
        /// Creates a Pix transaction based on the provided context.
        /// </summary>
        /// <param name="contexto">The context for the Pix transaction.</param>
        /// <returns>An instance of <see cref="ITransacaoPix"/>.</returns>
        ITransacaoPix Criar(PixContexto contexto);
    }
}
