using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Processing;

/// <summary>
/// 
/// </summary>
public class PixCopiaEColaStrategy : IPixProcessingStrategy
{
    /// <summary>
    /// 
    /// </summary>
    public FormaProcessamentoPix Tipo => FormaProcessamentoPix.CopiaECola;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contexto"></param>
    public void Process(PixContextoBase contexto)
    {
        Console.WriteLine($"Pix Copia e Cola processado {@contexto}");
    }
}
