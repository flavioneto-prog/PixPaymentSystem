namespace PixPaymentSystem.Domain.Pix.Validators
{
    /// <summary>
    /// Represents an abstract base class for handling Pix validation logic.
    /// </summary>
    public abstract class PixValidationHandler
    {
        private PixValidationHandler? next;

        /// <summary>
        /// Sets the next handler in the validation chain.
        /// </summary>
        /// <param name="next">The next <see cref="PixValidationHandler"/> in the chain.</param>
        /// <returns>The next handler in the chain.</returns>
        public PixValidationHandler SetNext(PixValidationHandler next)
        {
            this.next = next;
            return next;
        }

        /// <summary>
        /// Validates the specified Pix transaction value.
        /// </summary>
        /// <param name="valor">The value of the Pix transaction to validate.</param>
        public virtual void Validar(decimal valor)
        {
            next?.Validar(valor);
        }
    }
}
