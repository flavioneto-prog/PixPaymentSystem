using PixPaymentSystem.Domain.Pix;
using FluentAssertions;

namespace PixPaymentSystem.Tests.Unit.Domain.Pix
{
    public class PixImediatoTests
    {
        [Fact]
        public void Processar_QuandoChamado_DeveExecutarSemErro()
        {
            // Arrange
            var pix = new PixImediato();

            // Act
            var act = () => pix.Processar(100);

            // Assert
            act.Should().NotThrow();
        }
    }
}
