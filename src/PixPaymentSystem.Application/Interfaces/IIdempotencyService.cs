namespace PixPaymentSystem.Application.Interfaces
{
    /// <summary>
    /// Interface para gerenciar a idempotência de operações.
    /// </summary>
    public interface IIdempotencyService
    {
        /// <summary>
        /// Verifica se uma operação com a chave especificada já foi processada.
        /// </summary>
        /// <param name="key">A chave única que identifica a operação.</param>
        /// <returns>Retorna <c>true</c> se a operação já foi processada; caso contrário, <c>false</c>.</returns>
        bool JaProcessado(string key);

        /// <summary>
        /// Registra uma operação como processada com a chave e a resposta associadas.
        /// </summary>
        /// <param name="key">A chave única que identifica a operação.</param>
        /// <param name="response">A resposta associada à operação processada.</param>
        void Registrar(string key, object response);

        /// <summary>
        /// Obtém a resposta associada a uma operação processada com a chave especificada.
        /// </summary>
        /// <param name="key">A chave única que identifica a operação.</param>
        /// <returns>A resposta associada à operação, ou <c>null</c> se a operação não foi encontrada.</returns>
        object? ObterResposta(string key);
    }
}
