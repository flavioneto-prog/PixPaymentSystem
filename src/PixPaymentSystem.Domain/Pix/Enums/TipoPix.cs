namespace PixPaymentSystem.Domain.Pix.Enums;

/// <summary>
/// Represents the type of Pix transaction.
/// </summary>
public enum TipoPix
{
    /// <summary>
    /// Immediate Pix transaction.
    /// </summary>
    Imediato,

    /// <summary>
    /// Scheduled Pix transaction.
    /// </summary>
    Agendado,

    /// <summary>
    /// Recurring Pix transaction.
    /// </summary>
    Recorrente,

    /// <summary>
    /// Pix transaction for billing purposes.
    /// </summary>
    Cobranca,

    /// <summary>
    /// Pix transaction for withdrawal or change.
    /// </summary>
    SaqueOuTroco,
}
