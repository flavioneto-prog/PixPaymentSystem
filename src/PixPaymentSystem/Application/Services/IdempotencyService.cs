using System.Collections.Concurrent;
using PixPaymentSystem.Application.Interfaces;

namespace PixPaymentSystem.Application.Services
{
    public class IdempotencyService : IIdempotencyService
    {
        private readonly ConcurrentDictionary<string, object> _cache = new();

        public bool JaProcessado(string key)
        {
            return _cache.ContainsKey(key);
        }

        public void Registrar(string key, object response)
        {
            _cache[key] = response;
        }

        public object? ObterResposta(string key)
        {
            _cache.TryGetValue(key, out var response);
            return response;
        }
    }
}
