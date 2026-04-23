using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Imediato;
using PixPaymentSystem.Domain.Pix.Resolvers;

namespace PixPaymentSystem.Application.Factories;

/// <summary>
/// 
/// </summary>
public sealed class PixImediatoFactory(PixProcessingStrategyResolver resolver) : IPixFactory
{
    /// <summary>
    /// Gets the type of Pix handled by this factory.
    /// </summary>
    public TipoPix Tipo => TipoPix.Imediato;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contextoBase"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public ITransacaoPix Criar(PixContextoBase contextoBase)
    {
        var contexto = (PixImediatoContexto)contextoBase ?? throw new ArgumentNullException(nameof(contextoBase), "O contexto não pode ser nulo.");

        var strategy = resolver.Resolve(contexto.FormaProcessamento);

        return new PixImediato(strategy, contexto);
    }
}