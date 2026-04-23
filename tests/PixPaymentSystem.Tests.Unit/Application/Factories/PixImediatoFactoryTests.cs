namespace PixPaymentSystem.Tests.Unit.Application.Factories
{
    using FluentAssertions;
    using PixPaymentSystem.Application.Factories;
    using PixPaymentSystem.Domain.Pix;

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