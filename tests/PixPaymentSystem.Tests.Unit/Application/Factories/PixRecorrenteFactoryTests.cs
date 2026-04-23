namespace PixPaymentSystem.Tests.Unit.Application.Factories
{
    using FluentAssertions;
    using PixPaymentSystem.Application.Factories;
    using PixPaymentSystem.Domain.Pix;

    public class PixRecorrenteFactoryTests
    {
        [Fact]
        public void Criar_QuandoChamado_DeveRetornarPixRecorrente()
        {
            // Arrange
            var factory = new PixRecorrenteFactory();
            var contexto = new PixContexto()
            {
                DataFim = DateTime.UtcNow.AddMonths(1),
                FrequenciaDias = 1,
            };

            // Act
            var resultado = factory.Criar(contexto);

            // Assert
            resultado.Should().BeOfType<PixRecorrente>();
        }

        [Fact]
        public void Criar_QuandoFrequenciaDiasNula_DeveLancarExcecao()
        {
            // Arrange
            var factory = new PixRecorrenteFactory();
            var contexto = new PixContexto()
            {
                DataFim = DateTime.UtcNow.AddMonths(1),
            };

            // Act
            var act = () => factory.Criar(contexto);

            // Act & Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("*FrequenciaDias é obrigatória para Pix Recorrente.*");
        }

        [Fact]
        public void Criar_QuandoDataFimNula_DeveLancarExcecao()
        {
            // Arrange
            var factory = new PixRecorrenteFactory();
            var contexto = new PixContexto()
            {
                FrequenciaDias = 1,
            };

            // Act
            var act = () => factory.Criar(contexto);

            // Act & Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("*DataFim é obrigatória para Pix Recorrente.*");
        }
    }
}