namespace PixPaymentSystem.Application.Factories
{
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Interfaces;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Factory class responsible for creating instances of PixRecorrente transactions.
    /// </summary>
    public sealed class PixRecorrenteFactory : IPixFactory
    {
        /// <summary>
        /// Gets the type of Pix transaction handled by this factory.
        /// </summary>
        public TipoPix Tipo => TipoPix.Recorrente;

        /// <summary>
        /// Creates a new instance of a PixRecorrente transaction based on the provided context.
        /// </summary>
        /// <param name="contexto">The context containing the necessary data to create the transaction.</param>
        /// <returns>A new instance of a PixRecorrente transaction.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the required properties <see cref="PixContexto.FrequenciaDias"/> or <see cref="PixContexto.DataFim"/> are null.
        /// </exception>
        public ITransacaoPix Criar(PixContexto contexto)
        {
            if(contexto is null)
            {
                throw new ArgumentNullException(nameof(contexto), "O contexto não pode ser nulo.");
            }

            if (contexto.FrequenciaDias is null)
            {
                throw new ArgumentException("FrequenciaDias é obrigatória para Pix Recorrente.");
            }

            if (contexto.DataFim is null)
            {
                throw new ArgumentException("DataFim é obrigatória para Pix Recorrente.");
            }

            return new PixRecorrente(contexto.FrequenciaDias.Value, contexto.DataFim.Value);
        }
    }
}
