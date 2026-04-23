using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Interfaces;

/// <summary>
/// Represents a factory for creating Pix transactions.
/// </summary>
public interface IPixFactory
{
    /// <summary>
    /// Gets the type of Pix transaction this factory handles.
    /// </summary>
    TipoPix Tipo { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contextoBase"></param>
    /// <returns></returns>
    ITransacaoPix Criar(PixContextoBase contextoBase);
}
