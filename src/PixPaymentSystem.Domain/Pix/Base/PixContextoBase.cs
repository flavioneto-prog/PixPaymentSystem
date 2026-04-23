using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Base;

/// <summary>
/// 
/// </summary>
/// <param name="FormaProcessamento"></param>
/// <param name="Valor"></param>
/// <param name="Chave"></param>
public abstract record PixContextoBase(
    FormaProcessamentoPix FormaProcessamento,
    decimal Valor,
    string? Chave
);