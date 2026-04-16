using PixPaymentSystem.Domain.Interfaces;

namespace PixPaymentSystem.Domain.Pix
{
    public sealed class PixAgendado : ITransacaoPix
    {
        private readonly DateTime _dataAgendamento;

        public PixAgendado(DateTime dataAgendamento)
        {
            if (dataAgendamento <= DateTime.UtcNow)
                throw new ArgumentException("A data de agendamento deve ser futura.");

            _dataAgendamento = dataAgendamento;
        }

        public void Processar(decimal valor)
        {
            Console.WriteLine($"Pix Agendado de R$ {valor} será processado em {_dataAgendamento:dd/MM/yyyy}");
        }
    }
}
