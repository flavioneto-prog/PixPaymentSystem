using PixPaymentSystem.Domain.Pix;
using FluentAssertions;

namespace PixPaymentSystem.Tests.Unit.Domain.Pix
{
    public class PixRecorrenteTests
    {
        [Fact]
        public void Construtor_QuandoFrequenciaDiasMenorIgualZero_DeveLancarArgumentException()
        {
            // Arrange
            var dataFutura = DateTime.UtcNow.AddMonths(6);
            var frequenciaDias = 0;

            // Act
            var act = () => new PixRecorrente(frequenciaDias, dataFutura);

            // Assert
            act.Should()
               .Throw<ArgumentException>()
               .WithMessage("*A frequência deve ser maior que zero.*");
        }

        [Fact]
        public void Construtor_QuandoDataMenorOuIgualDataAtual_DeveLancarArgumentException()
        {
            // Arrange
            var dataAtual = DateTime.UtcNow;
            var frequenciaDias = 1;

            // Act
            var act = () => new PixRecorrente(frequenciaDias, dataAtual);

            // Assert
            act.Should()
               .Throw<ArgumentException>()
               .WithMessage("*A data fim deve ser futura.*");
        }

        [Fact]
        public void Processar_QuandoChamado_DeveExecutarSemErro()
        {
            // Arrange
            var dataFutura = DateTime.UtcNow.AddDays(1);
            var frequenciaDias = 1;

            var pix = new PixRecorrente(frequenciaDias, dataFutura);

            // Act
            var act = () => pix.Processar(100);

            // Assert
            act.Should().NotThrow();
        }
    }
}
