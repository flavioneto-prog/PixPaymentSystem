using FluentAssertions;
using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Recorrente;
using PixPaymentSystem.Domain.Pix.Resolvers;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Application.Factories;

public class PixRecorrenteFactoryTests
{
    [Fact]
    public void Criar_QuandoChamado_DeveRetornarPixRecorrente()
    {
        // Arrange
        var strategy = new FakeStrategy(FormaProcessamentoPix.CopiaECola);
        var resolver = new PixProcessingStrategyResolver(new[] { strategy });

        var factory = new PixRecorrenteFactory(resolver);

        var contexto = new PixRecorrenteContexto(
            FormaProcessamentoPix.CopiaECola,
            100m,
            "chave@email.com",
            1,
            DateTime.UtcNow.AddMonths(1)
        );

        // Act
        var resultado = factory.Criar(contexto);

        // Assert
        resultado.Should().BeOfType<PixRecorrente>();
    }
}