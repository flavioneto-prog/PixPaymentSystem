using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Processing;

/// <summary>
/// 
/// </summary>
public class PixQrCodeEstaticoStrategy : IPixProcessingStrategy
{
    /// <summary>
    /// 
    /// </summary>
    public FormaProcessamentoPix Tipo => FormaProcessamentoPix.QrCodeEstatico;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contexto"></param>
    public void Process(PixContextoBase contexto)
    {
        Console.WriteLine($"Processando Pix QR Code Estático {@contexto}");
    }
}
