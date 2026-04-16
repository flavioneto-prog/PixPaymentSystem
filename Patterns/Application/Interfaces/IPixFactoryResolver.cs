using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix;

namespace PixPaymentSystem.Application.Interfaces
{
    public interface IPixFactoryResolver
    {
        ITransacaoPix Criar(TipoPix tipo, PixContexto pixContexto);
    }
}
