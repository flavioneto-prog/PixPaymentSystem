using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Processing;

namespace PixPaymentSystem.Domain.Pix.Recorrente;

/// <summary>
/// Representa uma transação Pix recorrente com frequência e data de término.
/// </summary>
public sealed class PixRecorrente(IPixProcessingStrategy strategy, PixRecorrenteContexto pixRecorrenteContexto) : ITransacaoPix
{
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public void Processar()
    {
        if (pixRecorrenteContexto.FrequenciaDias <= 0)
        {
            throw new ArgumentException("A frequência deve ser maior que zero.");
        }

        if (pixRecorrenteContexto.DataFim <= DateTime.UtcNow)
        {
            throw new ArgumentException("A data fim deve ser futura.");
        }

        strategy.Process(pixRecorrenteContexto);
    }
}