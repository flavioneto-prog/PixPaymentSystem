using FluentAssertions;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Recorrente;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Domain.Pix;

public class PixRecorrenteTests
{
    [Fact]
    public void Processar_QuandoChamado_DeveExecutarSemErro()
    {
        // Arrange
        var contexto = new PixRecorrenteContexto(
            FormaProcessamentoPix.CopiaECola,
            100m,
            "chave@email.com",
            1,
            DateTime.UtcNow.AddMonths(6)
        );

        var strategy = new FakeStrategy(FormaProcessamentoPix.CopiaECola);

        var pix = new PixRecorrente(strategy, contexto);

        // Act
        var act = pix.Processar;

        // Assert
        act.Should().NotThrow();
    }
}
