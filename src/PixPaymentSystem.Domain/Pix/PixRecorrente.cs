namespace PixPaymentSystem.Domain.Pix
{
    using PixPaymentSystem.Domain.Interfaces;

    /// <summary>
    /// Representa uma transação Pix recorrente com frequência e data de término.
    /// </summary>
    public sealed class PixRecorrente : ITransacaoPix
    {
        private readonly int frequenciaDias;
        private readonly DateTime dataFim;

        /// <summary>
        /// Initializes a new instance of the <see cref="PixRecorrente"/> class.
        /// </summary>
        /// <param name="frequenciaDias">A frequência em dias entre cada transação.</param>
        /// <param name="dataFim">A data de término da recorrência.</param>
        /// <exception cref="ArgumentException">
        /// Lançada quando a frequência é menor ou igual a zero ou a data de término não é futura.
        /// </exception>
        public PixRecorrente(int frequenciaDias, DateTime dataFim)
        {
            if (frequenciaDias <= 0)
            {
                throw new ArgumentException("A frequência deve ser maior que zero.");
            }

            if (dataFim <= DateTime.UtcNow)
            {
                throw new ArgumentException("A data fim deve ser futura.");
            }

            this.frequenciaDias = frequenciaDias;
            this.dataFim = dataFim;
        }

        /// <summary>
        /// Processa a transação Pix recorrente com o valor especificado.
        /// </summary>
        /// <param name="valor">O valor da transação.</param>
        public void Processar(decimal valor)
        {
            Console.WriteLine($"Pix Recorrente de R$ {valor} a cada {frequenciaDias} dia(s) até {dataFim:dd/MM/yyyy}");
        }
    }
}