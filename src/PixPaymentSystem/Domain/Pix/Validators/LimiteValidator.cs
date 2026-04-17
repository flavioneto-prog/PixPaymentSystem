namespace PixPaymentSystem.Domain.Pix.Validators
{
    public class LimiteValidator : PixValidationHandler
    {
        public override void Validar(decimal valor)
        {
            if (valor > 1000)
                throw new Exception("Limite excedido");

            base.Validar(valor);
        }
    }
}
