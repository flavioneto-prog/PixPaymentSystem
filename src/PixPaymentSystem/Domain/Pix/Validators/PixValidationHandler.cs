namespace PixPaymentSystem.Domain.Pix.Validators
{
    public abstract class PixValidationHandler
    {
        protected PixValidationHandler? Next;

        public PixValidationHandler SetNext(PixValidationHandler next)
        {
            Next = next;
            return next;
        }

        public virtual void Validar(decimal valor)
        {
            Next?.Validar(valor);
        }
    }
}
