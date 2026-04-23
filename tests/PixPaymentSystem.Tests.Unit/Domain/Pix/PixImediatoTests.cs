using FluentAssertions;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Imediato;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Domain.Pix;

public class PixImediatoTests
{
    [Fact]
    public void Processar_QuandoChamado_DeveExecutarSemErro()
    {
        // Arrange
        var contexto = new PixImediatoContexto(
            FormaProcessamentoPix.CopiaECola,
            100m,
            "chave@email.com"
        );

        var strategy = new FakeStrategy(FormaProcessamentoPix.CopiaECola);

        var pix = new PixImediato(strategy, contexto);

        // Act
        var act = pix.Processar;

        // Assert
        act.Should().NotThrow();
    }
}
