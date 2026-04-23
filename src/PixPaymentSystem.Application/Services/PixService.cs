namespace PixPaymentSystem.Application.Services
{
    using Microsoft.Extensions.Logging;
    using PixPaymentSystem.Application.Interfaces;
    using PixPaymentSystem.Application.Logging;
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Interfaces;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Service responsible for processing Pix transactions.
    /// </summary>
    public partial class PixService(IPixFactoryResolver resolver, ILogger<PixService> logger, IPixValidatorChain validatorChain)
        : IPixService
    {
        /// <summary>
        /// Executes a Pix transaction based on the specified type, value, and context.
        /// </summary>
        /// <param name="tipo">The type of the Pix transaction.</param>
        /// <param name="valor">The value of the Pix transaction.</param>
        /// <param name="contexto">The context of the Pix transaction.</param>
        public void Executar(TipoPix tipo, decimal valor, PixContexto contexto)
        {
            PixLogging.LogIniciandoProcessamentoPix(logger, tipo, valor);

            validatorChain.Validar(valor);

            var transacao = resolver.Criar(tipo, contexto);
            transacao.Processar(valor);

            PixLogging.LogPixProcessadoComSucesso(logger, tipo, valor);
        }
    }
}
