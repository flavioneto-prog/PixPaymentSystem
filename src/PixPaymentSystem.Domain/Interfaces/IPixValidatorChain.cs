namespace PixPaymentSystem.Domain.Interfaces;

/// <summary>
/// Represents a chain of validators for PIX payment operations.
/// </summary>
public interface IPixValidatorChain
{
    /// <summary>
    /// Validates the specified payment value.
    /// </summary>
    /// <param name="valor">The payment value to validate.</param>
    void Validar(decimal valor);
}
