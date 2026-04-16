using PixPaymentSystem.Domain.Pix;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;

namespace PixPaymentSystem.Application.Factories
{
    public sealed class PixAgendadoFactory : IPixFactory
    {
        public TipoPix Tipo => TipoPix.Agendado;

        public ITransacaoPix Criar(PixContexto contexto)
        {
            if (contexto.DataAgendamento is null)
                throw new ArgumentException("DataAgendamento é obrigatória para Pix Agendado.");

            return new PixAgendado(contexto.DataAgendamento.Value);
        }
    }
}