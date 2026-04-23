namespace PixPaymentSystem.Tests.Unit.Application.Services
{
    using FluentAssertions;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using NSubstitute;
    using PixPaymentSystem.Application.Factories;
    using PixPaymentSystem.Application.Services;
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Interfaces;
    using PixPaymentSystem.Domain.Pix;

    public class PixServiceTests
    {
        private readonly ILogger<PixService> _logger = NullLogger<PixService>.Instance;
        private readonly IPixValidatorChain _validatorChain = Substitute.For<IPixValidatorChain>();

        [Fact]
        public void Executar_QuandoPixImediato_DeveProcessarSemErro()
        {
            // Arrange
            var factories = new List<IPixFactory>
            {
                new PixImediatoFactory(),
            };

            var resolver = new PixFactoryResolver(factories);
            var service = new PixService(resolver, _logger, _validatorChain);
            var tipoPix = TipoPix.Imediato;
            var valor = 100;

            var contexto = new PixContexto { };

            // Act
            var act = () => service.Executar(tipoPix, valor, contexto);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Executar_QuandoTipoInvalido_DeveLancarExcecao()
        {
            // Arrange
            var factories = new List<IPixFactory>();
            var resolver = new PixFactoryResolver(factories);
            var service = new PixService(resolver, _logger, _validatorChain);

            var tipoInvalido = (TipoPix)999;
            var contexto = new PixContexto();

            // Act
            var act = () => service.Executar(tipoInvalido, 100, contexto);

            // Assert
            act.Should().Throw<NotSupportedException>();
        }

        [Fact]
        public void Executar_QuandoPixAgendadoSemData_DeveLancarExcecao()
        {
            // Arrange
            var factories = new List<IPixFactory>
            {
                new PixAgendadoFactory(),
            };

            var resolver = new PixFactoryResolver(factories);
            var service = new PixService(resolver, _logger, _validatorChain);

            var contexto = new PixContexto();

            // Act
            var act = () => service.Executar(TipoPix.Agendado, 100, contexto);

            // Assert
            act.Should()
               .Throw<ArgumentException>()
               .WithMessage("*DataAgendamento*");
        }
    }
}
