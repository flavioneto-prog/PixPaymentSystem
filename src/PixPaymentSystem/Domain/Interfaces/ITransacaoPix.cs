namespace PixPaymentSystem.Domain.Interfaces
{
    public interface ITransacaoPix
    {
        void Processar(decimal valor);
    }
}