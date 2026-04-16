using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix;

namespace PixPaymentSystem.Application.Factories
{
    public sealed class PixFactoryResolver(IEnumerable<IPixFactory> factories) : IPixFactoryResolver
    {
        private readonly IReadOnlyDictionary<TipoPix, IPixFactory> _factories = factories.ToDictionary(f => f.Tipo);

        public ITransacaoPix Criar(TipoPix tipo, PixContexto contexto) =>
            _factories.TryGetValue(tipo, out var factory)
                ? factory.Criar(contexto)
                : throw new NotSupportedException($"Tipo {tipo} de Pix não suportado.");

    }
}