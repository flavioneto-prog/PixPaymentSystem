using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Pix.Validators;

namespace PixPaymentSystem.Application.Pipelines.Chains
{
    public class PixValidatorChain : IPixValidatorChain
    {
        private readonly PixValidationHandler _chain;

        public PixValidatorChain(IEnumerable<PixValidationHandler> validators)
        {
            var lista = validators.ToList();

            for (int i = 0; i < lista.Count - 1; i++)
            {
                lista[i].SetNext(lista[i + 1]);
            }

            _chain = lista.First();
        }

        public void Validar(decimal valor)
        {
            _chain.Validar(valor);
        }
    }
}
