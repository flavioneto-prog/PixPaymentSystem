using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Pix;

namespace PixPaymentSystem.Application.Interfaces
{
    public interface IPixService
    {
        void Executar(TipoPix tipo, decimal valor, PixContexto contexto);
    }
}
