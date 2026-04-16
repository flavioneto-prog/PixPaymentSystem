using PixPaymentSystem.Application.Factories;
using PixPaymentSystem.Domain.Pix;
using FluentAssertions;

namespace PixPaymentSystem.Tests.Unit.Application.Factories
{
    public class PixImediatoFactoryTests
    {
        [Fact]
        public void Criar_QuandoChamado_DeveRetornarPixImediato()
        {
            // Arrange
            var factory = new PixImediatoFactory();
            var contexto = new PixContexto();

            // Act
            var resultado = factory.Criar(contexto);

            // Assert
            resultado.Should().BeOfType<PixImediato>();
        }
    }
}