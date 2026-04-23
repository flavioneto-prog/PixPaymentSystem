using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Recorrente;
using PixPaymentSystem.Domain.Pix.Resolvers;

namespace PixPaymentSystem.Application.Factories;

/// <summary>
/// Factory class responsible for creating instances of PixRecorrente transactions.
/// </summary>
public sealed class PixRecorrenteFactory(PixProcessingStrategyResolver resolver) : IPixFactory
{
    /// <summary>
    /// Gets the type of Pix transaction handled by this factory.
    /// </summary>
    public TipoPix Tipo => TipoPix.Recorrente;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contextoBase"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public ITransacaoPix Criar(PixContextoBase contextoBase)
    {
        var contexto = (PixRecorrenteContexto)contextoBase ?? throw new ArgumentNullException(nameof(contextoBase), "O contexto não pode ser nulo.");

        var strategy = resolver.Resolve(contexto.FormaProcessamento);

        return new PixRecorrente(strategy, contexto);
    }
}
