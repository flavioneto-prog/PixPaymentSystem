using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Application.Resolvers;
using PixPaymentSystem.Application.Services;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Imediato;
using PixPaymentSystem.Domain.Pix.Resolvers;
using PixPaymentSystem.Tests.Unit.Fakers;

namespace PixPaymentSystem.Tests.Unit.Application.Services;

public class PixServiceTests
{
    private readonly ILogger<PixService> _logger = NullLogger<PixService>.Instance;
    private readonly IPixValidatorChain _validatorChain = Substitute.For<IPixValidatorChain>();

    [Fact]
    public void Executar_QuandoPixImediato_DeveProcessarSemErro()
    {
        // Arrange
        var strategy = new FakeStrategy(FormaProcessamentoPix.QrCodeEstatico);
        var strategyResolver = new PixProcessingStrategyResolver(new[] { strategy });

        var factories = new List<IPixFactory>
        {
            new PixImediatoFactory(strategyResolver),
        };

        var resolver = new PixFactoryResolver(factories);

        var service = new PixService(resolver, _logger, _validatorChain);

        var contexto = new PixImediatoContexto(
            FormaProcessamentoPix.QrCodeEstatico,
            100m,
            "chave@email.com"
        );

        // Act
        var act = () => service.Executar(TipoPix.Imediato, contexto);

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void Executar_QuandoTipoInvalido_DeveLancarExcecao()
    {
        // Arrange
        var resolver = new PixFactoryResolver([]);

        var service = new PixService(resolver, _logger, _validatorChain);

        var contexto = new PixImediatoContexto(
            FormaProcessamentoPix.Chave,
            100m,
            "chave@email.com"
        );

        var tipoInvalido = (TipoPix)999;

        // Act
        var act = () => service.Executar(tipoInvalido, contexto);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }
}