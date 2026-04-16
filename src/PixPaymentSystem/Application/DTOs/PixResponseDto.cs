namespace PixPaymentSystem.Application.DTOs
{
    public sealed class PixResponseDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = default!;
        public decimal Valor { get; set; }
        public string Status { get; set; } = "Processado";
    }
}
