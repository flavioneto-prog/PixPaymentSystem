using PixPaymentSystem.Domain.Pix.Base;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Processing;

namespace PixPaymentSystem.Tests.Unit.Fakers;

public class FakeStrategy(FormaProcessamentoPix tipo) : IPixProcessingStrategy
{
    public FormaProcessamentoPix Tipo { get; } = tipo;

    public void Process(PixContextoBase contexto)
    {
    }
}