using Microsoft.Extensions.Logging;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix;

namespace PixPaymentSystem.Application.Factories
{
    public class PixFactoryResolver(
        IEnumerable<IPixFactory> factories,
        ILogger<PixFactoryResolver> logger) : IPixFactoryResolver
    {
        private readonly IReadOnlyDictionary<TipoPix, IPixFactory> _factories = factories.ToDictionary(f => f.Tipo);

        public ITransacaoPix Criar(TipoPix tipo, PixContexto contexto)
        {
            logger.LogInformation("Criando transação PIX do tipo {Tipo}", tipo);

            if (!_factories.TryGetValue(tipo, out var factory))
                throw new NotSupportedException($"Tipo {tipo} não suportado.");

            return factory.Criar(contexto);
        }
    }
}