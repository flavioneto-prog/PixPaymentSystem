namespace PixPaymentSystem.Domain.Pix
{
    /// <summary>
    /// Contexto utilizado para fornecer informações adicionais sobre o processamento do Pix, como data de agendamento, frequência de recorrência e data de término.
    /// </summary>
    /// <param name="DataAgendamento">Caso seja um Pix Agendado é necessário informar a Data de Agendamento.</param>
    /// <param name="FrequenciaDias">Caso seja um Pix Recorrente é necessário informar a Frequência de dias e Data fim.</param>
    /// <param name="DataFim">Caso seja um Pix Recorrente é necessário informar a Data fim.</param>
    public record PixContexto(DateTime? DataAgendamento = null, int? FrequenciaDias = null, DateTime? DataFim = null);
}
