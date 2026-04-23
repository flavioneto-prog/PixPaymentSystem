using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Application.Interfaces;

/// <summary>
/// Defines the contract for a service that handles Pix operations.
/// </summary>
public interface IPixService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipoPix"></param>
    /// <param name="contextoBase"></param>
    void Executar(TipoPix tipoPix, PixContextoBase contextoBase);
}
