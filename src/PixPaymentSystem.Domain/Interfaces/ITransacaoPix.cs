namespace PixPaymentSystem.Domain.Interfaces
{
    /// <summary>
    /// Interface que define a operação de processamento de uma transação Pix.
    /// </summary>
    public interface ITransacaoPix
    {
        /// <summary>
        /// Processa uma transação Pix com o valor especificado.
        /// </summary>
        /// <param name="valor">O valor da transação a ser processada.</param>
        void Processar(decimal valor);
    }
}