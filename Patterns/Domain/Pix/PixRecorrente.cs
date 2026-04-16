using PixPaymentSystem.Domain.Interfaces;

namespace PixPaymentSystem.Domain.Pix
{
    public sealed class PixRecorrente : ITransacaoPix
    {
        private readonly int _frequenciaDias;
        private readonly DateTime _dataFim;

        public PixRecorrente(int frequenciaDias, DateTime dataFim)
        {
            if (frequenciaDias <= 0)
                throw new ArgumentException("A frequência deve ser maior que zero.");
            if (dataFim <= DateTime.UtcNow)
                throw new ArgumentException("A data fim deve ser futura.");

            _frequenciaDias = frequenciaDias;
            _dataFim = dataFim;
        }

        public void Processar(decimal valor)
        {
            Console.WriteLine($"Pix Recorrente de R$ {valor} a cada {_frequenciaDias} dia(s) até {_dataFim:dd/MM/yyyy}");
        }
    }
}
