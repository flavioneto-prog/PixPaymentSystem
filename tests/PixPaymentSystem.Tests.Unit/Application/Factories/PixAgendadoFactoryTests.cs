namespace PixPaymentSystem.Tests.Unit.Application.Factories
{
    using FluentAssertions;
    using PixPaymentSystem.Application.Factories;
    using PixPaymentSystem.Domain.Pix;

    public class PixAgendadoFactoryTests
    {
        [Fact]
        public void Criar_QuandoDataAgendamentoValida_DeveCriarPixAgendado()
        {
            // Arrange
            var factory = new PixAgendadoFactory();
            var contexto = new PixContexto
            {
                DataAgendamento = DateTime.UtcNow.AddDays(1),
            };

            // Act
            var resultado = factory.Criar(contexto);

            // Assert
            resultado.Should().BeOfType<PixAgendado>();
        }

        [Fact]
        public void Criar_QuandoDataAgendamentoNula_DeveLancarExcecao()
        {
            // Arrange
            var factory = new PixAgendadoFactory();
            var contexto = new PixContexto();

            // Act
            var act = () => factory.Criar(contexto);

            // Act & Assert
            act.Should()
                .Throw<ArgumentException>()
                .WithMessage("*DataAgendamento é obrigatória para Pix Agendado.*");
        }
    }
}
