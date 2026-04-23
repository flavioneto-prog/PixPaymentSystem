using FluentAssertions;
using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Imediato;
using PixPaymentSystem.Domain.Pix.Resolvers;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Application.Factories;

public class PixImediatoFactoryTests
{
    [Fact]
    public void Criar_QuandoChamado_DeveRetornarPixImediato()
    {
        // Arrange
        var strategy = new FakeStrategy(FormaProcessamentoPix.CopiaECola);
        var resolver = new PixProcessingStrategyResolver(new[] { strategy });

        var factory = new PixImediatoFactory(resolver);

        var contexto = new PixImediatoContexto(
            FormaProcessamentoPix.CopiaECola,
            100m,
            "chave@email.com"
        );

        // Act
        var resultado = factory.Criar(contexto);

        // Assert
        resultado.Should().BeOfType<PixImediato>();
    }
}