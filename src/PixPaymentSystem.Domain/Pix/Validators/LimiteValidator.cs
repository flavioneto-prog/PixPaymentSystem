namespace PixPaymentSystem.Domain.Pix.Validators;

/// <summary>
/// Represents a validator that checks if a given value exceeds the allowed limit.
/// </summary>
public class LimiteValidator : PixValidationHandler
{
    /// <summary>
    /// Validates the specified value to ensure it does not exceed the limit.
    /// </summary>
    /// <param name="valor">The value to validate.</param>
    /// <exception cref="Exception">Thrown when the value exceeds the limit.</exception>
    public override void Validar(decimal valor)
    {
        if (valor > 1000)
        {
            throw new ArgumentException("Limite excedido");
        }

        base.Validar(valor);
    }
}
