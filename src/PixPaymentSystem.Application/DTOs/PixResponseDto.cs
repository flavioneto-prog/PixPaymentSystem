namespace PixPaymentSystem.Application.DTOs;

/// <summary>
/// Represents the response data transfer object for a Pix payment.
/// </summary>
public sealed class PixResponseDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the Pix transaction.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the Pix transaction.
    /// </summary>
    public string Tipo { get; set; } = default!;

    /// <summary>
    /// Gets or sets the value of the Pix transaction.
    /// </summary>
    public decimal Valor { get; set; }

    /// <summary>
    /// Gets or sets the status of the Pix transaction.
    /// Default value is "Processado".
    /// </summary>
    public string Status { get; set; } = "Processado";
}
