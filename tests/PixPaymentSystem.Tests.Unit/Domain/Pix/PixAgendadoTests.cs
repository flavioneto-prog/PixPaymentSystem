using FluentAssertions;
using PixPaymentSystem.Domain.Pix.Agendado;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Domain.Pix;

public class PixAgendadoTests
{
    [Fact]
    public void Processar_QuandoChamado_DeveExecutarSemErro()
    {
        // Arrange
        var contexto = new PixAgendadoContexto(
            FormaProcessamentoPix.Chave,
            100m,
            "chave@email.com",
            DateTime.UtcNow.AddDays(1)
        );

        var strategy = new FakeStrategy(FormaProcessamentoPix.Chave);

        var pix = new PixAgendado(strategy, contexto);

        // Act
        var act = pix.Processar;

        // Assert
        act.Should().NotThrow();
    }
}
