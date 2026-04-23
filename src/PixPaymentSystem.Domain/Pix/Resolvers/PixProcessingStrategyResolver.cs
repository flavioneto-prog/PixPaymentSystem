using PixPaymentSystem.Domain.Pix.Enums;
using PixPaymentSystem.Domain.Pix.Processing;

namespace PixPaymentSystem.Domain.Pix.Resolvers;

/// <summary>
/// 
/// </summary>
public class PixProcessingStrategyResolver(IEnumerable<IPixProcessingStrategy> strategies)
{
    private readonly Dictionary<FormaProcessamentoPix, IPixProcessingStrategy> _map = strategies.ToDictionary(s => s.Tipo);

    /// <summary>
    ///
    /// </summary>
    /// <param name="tipo"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public IPixProcessingStrategy Resolve(FormaProcessamentoPix tipo)
    {
        if (!_map.TryGetValue(tipo, out var strategy))
        {
            throw new InvalidOperationException($"Forma de processamento pix {tipo} não suportada.");
        }

        return strategy;
    }
}
