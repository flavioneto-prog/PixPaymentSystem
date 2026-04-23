namespace PixPaymentSystem.Application.Factories
{
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Interfaces;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Factory responsible for creating instances of PixAgendado transactions.
    /// </summary>
    public sealed class PixAgendadoFactory : IPixFactory
    {
        /// <summary>
        /// Gets the type of Pix transaction handled by this factory.
        /// </summary>
        public TipoPix Tipo => TipoPix.Agendado;

        /// <summary>
        /// Creates a new instance of a PixAgendado transaction.
        /// </summary>
        /// <param name="contexto">The context containing the necessary data for the transaction.</param>
        /// <returns>A new instance of <see cref="PixAgendado"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when the scheduling date is not provided.</exception>
        public ITransacaoPix Criar(PixContexto contexto)
        {
            if (contexto is null)
            {
                throw new ArgumentNullException(nameof(contexto), "O contexto não pode ser nulo.");
            }

            if (contexto.DataAgendamento is null)
            {
                throw new ArgumentException("DataAgendamento é obrigatória para Pix Agendado.");
            }

            return new PixAgendado(contexto.DataAgendamento.Value);
        }
    }
}