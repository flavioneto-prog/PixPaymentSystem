namespace PixPaymentSystem.Application.Factories
{
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Interfaces;
    using PixPaymentSystem.Domain.Pix;

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
        /// Creates a PIX transaction based on the specified type and context.
        /// </summary>
        /// <param name="tipo">The type of the PIX transaction.</param>
        /// <param name="pixContexto">The context for the PIX transaction.</param>
        /// <returns>The created PIX transaction.</returns>
        /// <exception cref="NotSupportedException">Thrown when the specified PIX type is not supported.</exception>
        public ITransacaoPix Criar(TipoPix tipo, PixContexto pixContexto)
        {
            if (!factories.TryGetValue(tipo, out var factory))
            {
                throw new NotSupportedException($"Tipo {tipo} de pix não suportado.");
            }

            return factory.Criar(pixContexto);
        }
    }
}