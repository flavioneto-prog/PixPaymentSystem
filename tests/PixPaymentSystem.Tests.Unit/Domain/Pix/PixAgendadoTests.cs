namespace PixPaymentSystem.Tests.Unit.Domain.Pix
{
    using FluentAssertions;
    using PixPaymentSystem.Domain.Pix;

    public class PixAgendadoTests
    {
        [Fact]
        public void Construtor_QuandoDataFutura_DeveCriarInstancia()
        {
            // Arrange
            var dataFutura = DateTime.UtcNow.AddDays(1);

            // Act
            var act = () => new PixAgendado(dataFutura);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Construtor_QuandoDataPassada_DeveLancarArgumentException()
        {
            // Arrange
            var dataPassada = DateTime.UtcNow.AddDays(-1);

            // Act
            var act = () => new PixAgendado(dataPassada);

            // Assert
            act.Should()
               .Throw<ArgumentException>()
               .WithMessage("*data de agendamento deve ser futura*");
        }

        [Fact]
        public void Construtor_QuandoDataAtual_DeveLancarArgumentException()
        {
            // Arrange
            var agora = DateTime.UtcNow;

            // Act
            var act = () => new PixAgendado(agora);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Processar_QuandoChamado_DeveExecutarSemErro()
        {
            // Arrange
            var dataFutura = DateTime.UtcNow.AddDays(1);
            var pix = new PixAgendado(dataFutura);

            // Act
            var act = () => pix.Processar(100);

            // Assert
            act.Should().NotThrow();
        }
    }
}
