using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Processing;

/// <summary>
/// 
/// </summary>
public class PixQrCodeDinamicoStrategy : IPixProcessingStrategy
{
    /// <summary>
    /// 
    /// </summary>
    public FormaProcessamentoPix Tipo => FormaProcessamentoPix.QrCodeDinamico;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contexto"></param>
    public void Process(PixContextoBase contexto)
    {
        Console.WriteLine($"Gerando QR Code Dinâmico {contexto}");
    }
}
