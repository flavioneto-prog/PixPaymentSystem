using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Pix;
using PixPaymentSystem.Tests.Integration.Base;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace PixPaymentSystem.Tests.Integration.PixService
{
    public class PixServiceIntegrationTests : IntegrationTestBase
    {
        [Fact]
        public void Executar_QuandoPixImediato_DeveExecutarFluxoCompleto()
        {
            // Arrange
            var service = Provider.GetRequiredService<IPixService>();
            var contexto = new PixContexto();

            // Act
            var act = () => service.Executar(TipoPix.Imediato, 100, contexto);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Executar_QuandoPixAgendadoValido_DeveExecutarFluxoCompleto()
        {
            // Arrange
            var service = Provider.GetRequiredService<IPixService>();
            var contexto = new PixContexto
            {
                DataAgendamento = DateTime.UtcNow.AddDays(1)
            };

            // Act
            Action act = () => service.Executar(TipoPix.Agendado, 100, contexto);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Executar_QuandoPixRecorrenteValido_DeveExecutarFluxoCompleto()
        {
            // Arrange
            var service = Provider.GetRequiredService<IPixService>();
            var contexto = new PixContexto
            {
                DataFim = DateTime.UtcNow.AddMonths(1),
                FrequenciaDias = 1
            };

            // Act
            Action act = () => service.Executar(TipoPix.Recorrente, 100, contexto);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Executar_QuandoPixAgendadoSemData_DeveFalharNoFluxoCompleto()
        {
            // Arrange
            var service = Provider.GetRequiredService<IPixService>();
            var contexto = new PixContexto();

            // Act
            Action act = () => service.Executar(TipoPix.Agendado, 100, contexto);

            // Assert
            act.Should()
               .Throw<ArgumentException>()
               .WithMessage("*DataAgendamento*");
        }

        [Fact]
        public void Executar_QuandoTipoInvalido_DeveFalharNoFluxoCompleto()
        {
            // Arrange
            var service = Provider.GetRequiredService<IPixService>();
            var contexto = new PixContexto();

            var tipoInvalido = (TipoPix)999;

            // Act
            Action act = () => service.Executar(tipoInvalido, 100, contexto);

            // Assert
            act.Should()
               .Throw<NotSupportedException>();
        }
    }
}
