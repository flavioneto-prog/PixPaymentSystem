using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Processing;

/// <summary>
/// 
/// </summary>
public interface IPixProcessingStrategy
{
    /// <summary>
    /// 
    /// </summary>
    FormaProcessamentoPix Tipo { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contexto"></param>
    /// <returns></returns>
    void Process(PixContextoBase contexto);
}
