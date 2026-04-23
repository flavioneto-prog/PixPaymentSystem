using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Processing;

/// <summary>
/// 
/// </summary>
public class PixChaveStrategy : IPixProcessingStrategy
{
    /// <summary>
    /// 
    /// </summary>
    public FormaProcessamentoPix Tipo => FormaProcessamentoPix.Chave;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contexto"></param>
    public void Process(PixContextoBase contexto)
    {
        Console.WriteLine($"Processando Pix por Chave {@contexto}");
    }
}
