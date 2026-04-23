namespace PixPaymentSystem.Application.Factories
{
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Interfaces;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Factory class responsible for creating instances of PixImediato.
    /// </summary>
    public sealed class PixImediatoFactory : IPixFactory
    {
        /// <summary>
        /// Singleton instance of PixImediato.
        /// </summary>
        private static readonly PixImediato Instance = new();

        /// <summary>
        /// Gets the type of Pix handled by this factory.
        /// </summary>
        public TipoPix Tipo => TipoPix.Imediato;

        /// <summary>
        /// Creates a new Pix transaction based on the provided context.
        /// </summary>
        /// <param name="contexto">The context for the Pix transaction.</param>
        /// <returns>An instance of <see cref="ITransacaoPix"/>.</returns>
        public ITransacaoPix Criar(PixContexto contexto) => Instance;
    }
}