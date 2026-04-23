using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Imediato;

/// <summary>
/// 
/// </summary>
/// <param name="FormaProcessamento"></param>
/// <param name="Valor"></param>
/// <param name="Chave"></param>
public record PixImediatoContexto(
    FormaProcessamentoPix FormaProcessamento,
    decimal Valor,
    string? Chave)
        : PixContextoBase(FormaProcessamento, Valor, Chave);