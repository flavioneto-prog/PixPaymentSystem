using Microsoft.Extensions.Logging;
using PixPaymentSystem.Application.DTOs;
using PixPaymentSystem.Domain.Pix.Enums;

namespace PixPaymentSystem.Application.Logging;

/// <summary>
/// Classe responsável pelos LOGS relacionados ao PIX no contexto da API.
/// </summary>
public static partial class PixLogging
{
    /// <summary>
    /// Log para coletar métricas sobre a requisição recebida.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="request"></param>
    /// <param name="key"></param>
    [LoggerMessage(Level = LogLevel.Information, Message = "Recebendo requisição de Pix {@Request} com IdempotencyKey {Key}")]
    public static partial void LogRequisicaoProcessarPix(ILogger logger, PixRequestDto request, string key);

    /// <summary>
    /// Log para coletar métricas de erro ao processar pix.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="exception"></param>
    /// <param name="request"></param>
    /// <param name="key"></param>
    [LoggerMessage(Level = LogLevel.Error, Message = "Erro ao processar a requisição de Pix {@Request} com IdempotencyKey {Key}")]
    public static partial void LogErroAoProcessarPix(ILogger logger, Exception exception, PixRequestDto request, string key);

    /// <summary>
    /// Log para coletar métricas sobre início de processamento de PIX.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="tipo"></param>
    /// <param name="valor"></param>
    [LoggerMessage(Level = LogLevel.Information, Message = "Iniciando processamento de Pix {Tipo} no valor de {Valor}")]
    public static partial void LogIniciandoProcessamentoPix(ILogger logger, TipoPix tipo, decimal valor);

    /// <summary>
    /// Log para coletar métricas para pix processado com sucesso.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="tipo"></param>
    /// <param name="valor"></param>
    [LoggerMessage(Level = LogLevel.Information, Message = "Pix processado com sucesso {Tipo} {Valor}")]
    public static partial void LogPixProcessadoComSucesso(ILogger logger, TipoPix tipo, decimal valor);
}