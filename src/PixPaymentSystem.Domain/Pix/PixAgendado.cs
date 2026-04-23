namespace PixPaymentSystem.Domain.Pix
{
    using PixPaymentSystem.Domain.Interfaces;

    /// <summary>
    /// Representa uma transação Pix agendada.
    /// </summary>
    public sealed class PixAgendado : ITransacaoPix
    {
        private readonly DateTime dataAgendamento;

        /// <summary>
        /// Initializes a new instance of the <see cref="PixAgendado"/> class.
        /// </summary>
        /// <param name="dataAgendamento">A data futura em que o Pix será processado.</param>
        /// <exception cref="ArgumentException">Lançada quando a data de agendamento não é futura.</exception>
        public PixAgendado(DateTime dataAgendamento)
        {
            if (dataAgendamento <= DateTime.UtcNow)
            {
                throw new ArgumentException("A data de agendamento deve ser futura.");
            }

            this.dataAgendamento = dataAgendamento;
        }

        /// <summary>
        /// Processa a transação Pix agendada.
        /// </summary>
        /// <param name="valor">O valor da transação Pix.</param>
        public void Processar(decimal valor)
        {
            Console.WriteLine($"Pix Agendado de R$ {valor} será processado em {dataAgendamento:dd/MM/yyyy}");
        }
    }
}
