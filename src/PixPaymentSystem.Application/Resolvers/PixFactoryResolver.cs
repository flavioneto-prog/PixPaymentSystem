using PixPaymentSystem.Domain.Interfaces;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Application.Resolvers;

/// <summary>
/// Resolves the appropriate PIX factory based on the provided PIX type.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PixFactoryResolver"/> class.
/// </remarks>
/// <param name="factories">The collection of available PIX factories.</param>
public partial class PixFactoryResolver(IEnumerable<IPixFactory> factories)
    : IPixFactoryResolver
{
    private readonly Dictionary<TipoPix, IPixFactory> factories = factories.ToDictionary(f => f.Tipo);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipo"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public IPixFactory Criar(TipoPix tipo)
    {
        if (!factories.TryGetValue(tipo, out var factory))
        {
            throw new NotSupportedException($"Tipo {tipo} de pix não suportado.");
        }

        return factory;
    }
}