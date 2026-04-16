using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix;
using FluentAssertions;

namespace PixPaymentSystem.Tests.Unit.Application.Factories
{
    public class PixFactoryResolverTests
    {
        [Fact]
        public void Criar_QuandoTipoImediato_DeveRetornarPixImediato()
        {
            // Arrange
            var factories = new List<IPixFactory>
            {
                new PixImediatoFactory(),
                new PixAgendadoFactory(),
                new PixRecorrenteFactory()
            };

            var resolver = new PixFactoryResolver(factories);
            var contexto = new PixContexto { };

            // Act
            var resultado = resolver.Criar(TipoPix.Imediato, contexto);

            // Assert
            resultado.Should().BeOfType<PixImediato>();
        }

        [Fact]
        public void Criar_QuandoTipoNaoSuportado_DeveLancarExcecao()
        {
            // Arrange
            var factories = new List<IPixFactory>();
            var resolver = new PixFactoryResolver(factories);
            var contexto = new PixContexto { };
            var tipoPixInexistente = (TipoPix)10000;

            // Act
            var act = () => resolver.Criar(tipoPixInexistente, contexto);

            // Act & Assert

            act.Should()
                .Throw<NotSupportedException>()
                .WithMessage($"*Tipo {tipoPixInexistente} de Pix não suportado.*");
        }
    }
}