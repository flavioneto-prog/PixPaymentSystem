namespace PixPaymentSystem.Application.DTOs
{
    /// <summary>
    /// Represents a request for a Pix payment.
    /// </summary>
    public sealed class PixRequestDto
    {
        /// <summary>
        /// Gets or sets the type of the Pix transaction.
        /// </summary>
        public string Tipo { get; set; } = default!;

        /// <summary>
        /// Gets or sets the value of the Pix transaction.
        /// </summary>
        public decimal Valor { get; set; } = default!;

        /// <summary>
        /// Gets or sets the scheduled date for the Pix transaction, if applicable.
        /// </summary>
        public DateTime? DataAgendamento { get; set; }

        /// <summary>
        /// Gets or sets the frequency in days for recurring Pix transactions, if applicable.
        /// </summary>
        public int? FrequenciaDias { get; set; }

        /// <summary>
        /// Gets or sets the end date for recurring Pix transactions, if applicable.
        /// </summary>
        public DateTime? DataFim { get; set; }
    }
}
