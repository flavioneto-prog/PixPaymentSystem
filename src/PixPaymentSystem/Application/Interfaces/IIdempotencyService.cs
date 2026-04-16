namespace PixPaymentSystem.Application.Interfaces
{
    public interface IIdempotencyService
    {
        bool JaProcessado(string key);

        void Registrar(string key, object response);

        object? ObterResposta(string key);
    }
}
