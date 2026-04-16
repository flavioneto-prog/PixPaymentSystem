namespace PixPaymentSystem.Domain.Pix
{
    public record PixContexto(
        DateTime? DataAgendamento = null,
        int? FrequenciaDias = null,
        DateTime? DataFim = null
    );
}
