using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Processing;

namespace PixPaymentSystem.Domain.Pix.Imediato;

/// <summary>
/// Represents an immediate Pix transaction.
/// </summary>
public sealed class PixImediato(IPixProcessingStrategy strategy, PixImediatoContexto pixImediatoContexto) : ITransacaoPix
{
    /// <summary>
    /// 
    /// </summary>
    public void Processar()
    {
        strategy.Process(pixImediatoContexto);
    }
}