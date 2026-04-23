using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Processing;

namespace PixPaymentSystem.Domain.Pix.Agendado;

/// <summary>
/// 
/// </summary>
/// <param name="strategy"></param>
/// <param name="pixAgendadoContexto"></param>
public sealed class PixAgendado(IPixProcessingStrategy strategy, PixAgendadoContexto pixAgendadoContexto) : ITransacaoPix
{
    /// <summary>
    /// 
    /// </summary>
    public void Processar()
    {
        if (pixAgendadoContexto is null)
        {
            throw new InvalidOperationException("O contexto de agendamento não pode ser nulo.");
        }

        if (pixAgendadoContexto.DataAgendamento <= DateTime.UtcNow)
        {
            throw new ArgumentException("A data de agendamento deve ser futura.");
        }

        strategy.Process(pixAgendadoContexto);
    }
}