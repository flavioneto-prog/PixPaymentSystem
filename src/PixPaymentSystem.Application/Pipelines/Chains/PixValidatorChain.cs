using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Validators;

namespace PixPaymentSystem.Application.Pipelines.Chains;

/// <summary>
/// Represents a chain of responsibility for validating Pix transactions.
/// </summary>
public class PixValidatorChain : IPixValidatorChain
{
    private readonly PixValidationHandler chain;

    /// <summary>
    /// Initializes a new instance of the <see cref="PixValidatorChain"/> class.
    /// Constructs the chain of validators from the provided list of handlers.
    /// </summary>
    /// <param name="validators">The collection of validation handlers to be linked in the chain.</param>
    public PixValidatorChain(IEnumerable<PixValidationHandler> validators)
    {
        var lista = validators.ToList();

        for (int i = 0; i < lista.Count - 1; i++)
        {
            lista[i].SetNext(lista[i + 1]);
        }

        chain = lista[0];
    }

    /// <summary>
    /// Validates the specified Pix transaction value using the chain of validators.
    /// </summary>
    /// <param name="valor">The value of the Pix transaction to be validated.</param>
    public void Validar(decimal valor)
    {
        chain.Validar(valor);
    }
}
