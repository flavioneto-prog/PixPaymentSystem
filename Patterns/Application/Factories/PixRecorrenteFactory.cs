using PixPaymentSystem.Domain.Pix;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Interfaces;

namespace PixPaymentSystem.Application.Factories
{
    public sealed class PixRecorrenteFactory : IPixFactory
    {
        public TipoPix Tipo => TipoPix.Recorrente;

        public ITransacaoPix Criar(PixContexto contexto)
        {
            if (contexto.FrequenciaDias is null)
                throw new ArgumentException("FrequenciaDias é obrigatória para Pix Recorrente.");
            if (contexto.DataFim is null)
                throw new ArgumentException("DataFim é obrigatória para Pix Recorrente.");

            return new PixRecorrente(contexto.FrequenciaDias.Value, contexto.DataFim.Value);
        }
    }
}
