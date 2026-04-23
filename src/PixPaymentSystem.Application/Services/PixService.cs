using Microsoft.Extensions.Logging;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Application.Logging;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Application.Services;

/// <summary>
/// Service responsible for processing Pix transactions.
/// </summary>
public partial class PixService(IPixFactoryResolver resolver, ILogger<PixService> logger, IPixValidatorChain validatorChain) : IPixService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipoPix"></param>
    /// <param name="contextoBase"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Executar(TipoPix tipoPix, PixContextoBase contextoBase)
    {
        if (contextoBase is null)
        {
            throw new InvalidOperationException(nameof(contextoBase));
        }

        PixLogging.LogIniciandoProcessamentoPix(logger, tipoPix, contextoBase.Valor);

        validatorChain.Validar(contextoBase.Valor);

        var factory = resolver.Criar(tipoPix);

        var transacao = factory.Criar(contextoBase);

        transacao.Processar();

        PixLogging.LogPixProcessadoComSucesso(logger, tipoPix, contextoBase.Valor);
    }
}
