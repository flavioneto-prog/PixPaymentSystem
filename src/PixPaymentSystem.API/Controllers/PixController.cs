namespace PixPaymentSystem.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PixPaymentSystem.Application.DTOs;
    using PixPaymentSystem.Application.Interfaces;
    using PixPaymentSystem.Application.Logging;
    using PixPaymentSystem.Domain.Enums;
    using PixPaymentSystem.Domain.Pix;

    /// <summary>
    /// Controller responsável por processar as requisições relacionadas ao Pix,
    /// incluindo a criação de novos Pix e a obtenção de detalhes de um Pix específico.
    /// </summary>
    /// <param name="pixService">Serviço responsável pelo processamento e obtenção do pix.</param>
    /// <param name="idempotencyService">Serviço responsável por garantir a idempotência.</param>
    /// <param name="logger">Logger para poder ter monitoramento sobre os métodos.</param>
    [ApiController]
    [Route("[controller]")]
    public partial class PixController(IPixService pixService, IIdempotencyService idempotencyService, ILogger<PixController> logger)
        : ControllerBase
    {
        /// <summary>
        /// Método responsável por processar uma requisição de criação de Pix,
        /// garantindo a idempotência da operação por meio do uso de uma chave única (Idempotency-Key) fornecida no cabeçalho da requisição.
        /// </summary>
        /// <param name="request">Body com os parametrôs necessários para processamento.</param>
        /// <param name="idempotencyKey">Chave única idempotência.</param>
        /// <returns>A new instance of <see cref="PixResponseDto"/>.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PixResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status500InternalServerError)]
        public IActionResult CriarPix(
            [FromBody] PixRequestDto request,
            [FromHeader(Name = "Idempotency-Key")] string idempotencyKey)
        {
            PixLogging.LogRequisicaoProcessarPix(logger, request, idempotencyKey);

            if (string.IsNullOrWhiteSpace(idempotencyKey))
            {
                return BadRequest("Idempotency-Key é obrigatório");
            }

            if (request is null)
            {
                return BadRequest("O corpo da requisição é obrigatório");
            }

            if (idempotencyService.JaProcessado(idempotencyKey))
            {
                var respostaAnterior = idempotencyService.ObterResposta(idempotencyKey);
                return Ok(respostaAnterior);
            }

            try
            {
                var tipo = Enum.Parse<TipoPix>(request.Tipo, true);

                var contexto = new PixContexto(
                    request.DataAgendamento,
                    request.FrequenciaDias,
                    request.DataFim);

                pixService.Executar(tipo, request.Valor, contexto);

                var response = new PixResponseDto
                {
                    Id = Guid.NewGuid(),
                    Tipo = tipo.ToString(),
                    Valor = request.Valor,
                };

                idempotencyService.Registrar(idempotencyKey, response);

                return CreatedAtAction(nameof(ObterPix), new { id = response.Id }, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                PixLogging.LogErroAoProcessarPix(logger, ex, request, idempotencyKey);
                throw;
            }
        }

        /// <summary>
        /// Método responsável por retornar os detalhes de um Pix específico com base no seu identificador único (ID).
        /// </summary>
        /// <param name="id">Identificador único.</param>
        /// <returns>A new instance of <see cref="PixResponseDto"/>.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PixResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterPix(Guid id)
        {
            // Simulação (sem banco ainda)
            var response = new PixResponseDto
            {
                Id = id,
                Tipo = "Imediato",
                Valor = 100,
                Status = "Processado",
            };

            return Ok(response);
        }
    }
}
