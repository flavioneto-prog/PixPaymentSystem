namespace PixPaymentSystem.Application.Services
{
    using System.Collections.Concurrent;
    using PixPaymentSystem.Application.Interfaces;

    /// <summary>
    /// Service responsible for handling idempotency by storing and retrieving processed requests.
    /// </summary>
    public class IdempotencyService : IIdempotencyService
    {
        private readonly ConcurrentDictionary<string, object> cache = new ();

        /// <summary>
        /// Checks if a request with the specified key has already been processed.
        /// </summary>
        /// <param name="key">The unique key identifying the request.</param>
        /// <returns>True if the request has been processed; otherwise, false.</returns>
        public bool JaProcessado(string key)
        {
            return cache.ContainsKey(key);
        }

        /// <summary>
        /// Registers a processed request with its associated response.
        /// </summary>
        /// <param name="key">The unique key identifying the request.</param>
        /// <param name="response">The response associated with the processed request.</param>
        public void Registrar(string key, object response)
        {
            cache[key] = response;
        }

        /// <summary>
        /// Retrieves the response associated with a processed request.
        /// </summary>
        /// <param name="key">The unique key identifying the request.</param>
        /// <returns>The response associated with the processed request, or null if not found.</returns>
        public object? ObterResposta(string key)
        {
            cache.TryGetValue(key, out var response);
            return response;
        }
    }
}
