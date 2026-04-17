using Microsoft.Extensions.Logging;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Pix;

namespace PixPaymentSystem.Application.Services
{
    public class PixService(
        IPixFactoryResolver resolver,
        ILogger<PixService> logger,
        IPixValidatorChain validatorChain) : IPixService
    {
        public void Executar(TipoPix tipo, decimal valor, PixContexto contexto)
        {
            logger.LogInformation(
                "Iniciando processamento de Pix {Tipo} no valor de {Valor}",
                tipo,
                valor
            );

            validatorChain.Validar(valor);

            var transacao = resolver.Criar(tipo, contexto);
            transacao.Processar(valor);

            logger.LogInformation(
                "Pix processado com sucesso {Tipo} {Valor}",
                tipo,
                valor
            );
        }
    }
}
