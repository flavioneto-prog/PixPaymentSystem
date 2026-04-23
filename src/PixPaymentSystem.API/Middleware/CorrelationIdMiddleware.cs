namespace PixPaymentSystem.API.Middleware
{
    /// <summary>
    /// Middleware responsável por gerenciar o cabeçalho de ID de correlação (X-Correlation-ID).
    /// </summary>
    /// <remarks>
    /// Inicializa uma nova instância da classe <see cref="CorrelationIdMiddleware"/>.
    /// </remarks>
    /// <param name="next">O próximo middleware na pipeline de requisição.</param>
    public class CorrelationIdMiddleware(RequestDelegate next)
    {
        private const string HeaderName = "X-Correlation-ID";

        /// <summary>
        /// Invoca o middleware para processar o contexto HTTP.
        /// </summary>
        /// <param name="context">O contexto HTTP atual.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task Invoke(HttpContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            var correlationId = context.Request.Headers[HeaderName].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            // Adiciona no contexto
            context.Items[HeaderName] = correlationId;

            // Adiciona na resposta
            context.Response.Headers[HeaderName] = correlationId;

            // Adiciona ao log context (Serilog)
            using (Serilog.Context.LogContext.PushProperty("CorrelationId", correlationId))
            {
                await next(context);
            }
        }
    }
}
