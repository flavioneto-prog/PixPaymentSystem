using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Recorrente;

/// <summary>
/// 
/// </summary>
/// <param name="FormaProcessamento"></param>
/// <param name="Valor"></param>
/// <param name="Chave"></param>
/// <param name="FrequenciaDias"></param>
/// <param name="DataFim"></param>
public record PixRecorrenteContexto(
    FormaProcessamentoPix FormaProcessamento,
    decimal Valor,
    string? Chave,
    int FrequenciaDias,
    DateTime DataFim
) : PixContextoBase(FormaProcessamento, Valor, Chave);
