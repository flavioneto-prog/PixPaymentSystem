using PixPaymentSystem.Domain.Pix;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;

namespace PixPaymentSystem.Application.Factories
{
    public sealed class PixImediatoFactory : IPixFactory
    {
        private static readonly PixImediato _instance = new();

        public TipoPix Tipo => TipoPix.Imediato;

        public ITransacaoPix Criar(PixContexto contexto) => _instance;
    }
}