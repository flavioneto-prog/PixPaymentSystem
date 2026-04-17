namespace PixPaymentSystem.Domain.Pix.Validators
{
    public class ValorNegativoValidator : PixValidationHandler
    {
        public override void Validar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Valor inválido");

            base.Validar(valor);
        }
    }
}
