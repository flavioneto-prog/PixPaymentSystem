using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Pix;

namespace PixPaymentSystem.Domain.Interfaces
{
    public interface IPixFactory
    {
        TipoPix Tipo { get; }

        ITransacaoPix Criar(PixContexto contexto);
    }
}
