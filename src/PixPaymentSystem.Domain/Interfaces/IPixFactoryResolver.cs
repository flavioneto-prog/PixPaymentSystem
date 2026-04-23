namespace PixPaymentSystem.Domain.Interfaces
{
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Interface responsável por resolver a fábrica de transações Pix com base no tipo de Pix e no contexto fornecido.
    /// </summary>
    public interface IPixFactoryResolver
    {
        /// <summary>
        /// Cria uma instância de <see cref="ITransacaoPix"/> com base no tipo de Pix e no contexto fornecido.
        /// </summary>
        /// <param name="tipo">O tipo de Pix.</param>
        /// <param name="pixContexto">O contexto do Pix.</param>
        /// <returns>Uma instância de <see cref="ITransacaoPix"/>.</returns>
        ITransacaoPix Criar(TipoPix tipo, PixContexto pixContexto);
    }
}
