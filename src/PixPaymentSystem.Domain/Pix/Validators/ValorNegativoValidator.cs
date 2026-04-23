namespace PixPaymentSystem.Domain.Pix.Validators
{
    /// <summary>
    /// Validator to ensure that the provided value is not negative or zero.
    /// </summary>
    public class ValorNegativoValidator : PixValidationHandler
    {
        /// <summary>
        /// Validates if the provided value is greater than zero.
        /// </summary>
        /// <param name="valor">The value to be validated.</param>
        /// <exception cref="Exception">Thrown when the value is less than or equal to zero.</exception>
        public override void Validar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Valor inválido");
            }

            base.Validar(valor);
        }
    }
}
