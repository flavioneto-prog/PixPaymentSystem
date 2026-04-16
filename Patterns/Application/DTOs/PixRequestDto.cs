namespace PixPaymentSystem.Application.DTOs
{
    public sealed class PixRequestDto
    {
        public string Tipo { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime? DataAgendamento { get; set; }
        public int? FrequenciaDias { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
