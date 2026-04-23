using FluentAssertions;
using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Domain.Pix.Agendado;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Resolvers;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Application.Factories;

public class PixAgendadoFactoryTests
{
    [Fact]
    public void Criar_QuandoDataAgendamentoValida_DeveCriarPixAgendado()
    {
        // Arrange
        var strategy = new FakeStrategy(FormaProcessamentoPix.Chave);
        var resolver = new PixProcessingStrategyResolver([strategy]);

        var factory = new PixAgendadoFactory(resolver);

        var contexto = new PixAgendadoContexto(
            FormaProcessamentoPix.Chave,
            100m,
            "chave@email.com",
            DateTime.UtcNow.AddDays(1)
        );

        // Act
        var resultado = factory.Criar(contexto);

        // Assert
        resultado.Should().BeOfType<PixAgendado>();
    }

    [Fact]
    public void Criar_QuandoDataAgendamentoInvalida_DeveLancarExcecao()
    {
        // Arrange
        var strategy = new FakeStrategy(FormaProcessamentoPix.Chave);
        var resolver = new PixProcessingStrategyResolver(new[] { strategy });

        var factory = new PixAgendadoFactory(resolver);

        var dataInvalida = DateTime.MinValue;

        var contexto = new PixAgendadoContexto(
            FormaProcessamentoPix.Chave,
            100m,
            "chave@email.com",
            dataInvalida
        );

        // Act
        var act = () => factory.Criar(contexto);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
