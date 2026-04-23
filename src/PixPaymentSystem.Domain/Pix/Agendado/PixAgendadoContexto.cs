using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Domain.Pix.Agendado;

/// <summary>
/// 
/// </summary>
/// <param name="FormaProcessamento"></param>
/// <param name="Valor"></param>
/// <param name="Chave"></param>
/// <param name="DataAgendamento"></param>
public record PixAgendadoContexto(
    FormaProcessamentoPix FormaProcessamento,
    decimal Valor,
    string? Chave,
    DateTime DataAgendamento
) : PixContextoBase(FormaProcessamento, Valor, Chave);
