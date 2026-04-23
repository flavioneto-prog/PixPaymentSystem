using FluentAssertions;
using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Application.Resolvers;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Imediato;
using PixPaymentSystem.Domain.Pix.Resolvers;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Application.Factories;

public class PixFactoryResolverTests
{
    private readonly PixProcessingStrategyResolver _strategyResolver;

    public PixFactoryResolverTests()
    {
        var strategy = new FakeStrategy(FormaProcessamentoPix.CopiaECola);
        _strategyResolver = new PixProcessingStrategyResolver([strategy]);
    }

    [Fact]
    public void Criar_QuandoTipoImediato_DeveRetornarFactoryCorreta()
    {
        // Arrange
        var factories = new List<IPixFactory>
        {
            new PixImediatoFactory(_strategyResolver),
            new PixAgendadoFactory(_strategyResolver),
            new PixRecorrenteFactory(_strategyResolver),
        };

        var resolver = new PixFactoryResolver(factories);

        // Act
        var factory = resolver.Criar(TipoPix.Imediato);

        // Assert
        factory.Should().BeOfType<PixImediatoFactory>();
    }

    [Fact]
    public void Criar_QuandoTipoImediato_DeveCriarPixImediato()
    {
        // Arrange
        var strategy = new FakeStrategy(FormaProcessamentoPix.CopiaECola);
        var strategyResolver = new PixProcessingStrategyResolver(new[] { strategy });

        var factories = new List<IPixFactory>
        {
            new PixImediatoFactory(strategyResolver),
            new PixAgendadoFactory(strategyResolver),
            new PixRecorrenteFactory(strategyResolver),
        };

        var resolver = new PixFactoryResolver(factories);

        var contexto = new PixImediatoContexto(
            FormaProcessamentoPix.CopiaECola,
            100m,
            "chave@email.com"
        );

        // Act
        var factory = resolver.Criar(TipoPix.Imediato);
        var resultado = factory.Criar(contexto);

        // Assert
        resultado.Should().BeOfType<PixImediato>();
    }

    [Fact]
    public void Criar_QuandoTipoNaoSuportado_DeveLancarExcecao()
    {
        // Arrange
        var resolver = new PixFactoryResolver([]);

        var tipoPixInexistente = (TipoPix)999;

        // Act
        var act = () => resolver.Criar(tipoPixInexistente);

        // Assert
        act.Should()
            .Throw<InvalidOperationException>()
            .WithMessage($"*{tipoPixInexistente}*");
    }
}