using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Agendado;
using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Resolvers;

namespace PixPaymentSystem.Application.Factories;

/// <summary>
/// Factory responsible for creating instances of PixAgendado transactions.
/// </summary>
public sealed class PixAgendadoFactory(PixProcessingStrategyResolver resolver) : IPixFactory
{
    /// <summary>
    /// Gets the type of Pix transaction handled by this factory.
    /// </summary>
    public TipoPix Tipo => TipoPix.Agendado;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contextoBase"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public ITransacaoPix Criar(PixContextoBase contextoBase)
    {
        var contexto = (PixAgendadoContexto)contextoBase ?? throw new ArgumentNullException(nameof(contextoBase), "O contexto não pode ser nulo.");

        var strategy = resolver.Resolve(contexto.FormaProcessamento);

        return new PixAgendado(strategy, contexto);
    }
}