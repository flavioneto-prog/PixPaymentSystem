using Microsoft.AspNetCore.Mvc;
using PixPaymentSystem.Application.DTOs;
using PixPaymentSystem.Application.Interfaces;
using PixPaymentSystem.Domain.Enums;
using PixPaymentSystem.Domain.Pix;

namespace PixPaymentSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PixController(
        IPixService pixService,
        IIdempotencyService idempotencyService,
        ILogger<PixController> logger) : ControllerBase
    {
        [HttpPost]
        public IActionResult CriarPix(
            [FromBody] PixRequestDto request,
            [FromHeader(Name = "Idempotency-Key")] string idempotencyKey)
        {
            logger.LogInformation("Recebendo requisição de Pix {@Request} com IdempotencyKey {Key}",
                request,
                idempotencyKey
            );

            if (string.IsNullOrWhiteSpace(idempotencyKey))
                return BadRequest("Idempotency-Key é obrigatório");

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
                    request.DataFim
                );

                pixService.Executar(tipo, request.Valor, contexto);

                var response = new PixResponseDto
                {
                    Id = Guid.NewGuid(),
                    Tipo = tipo.ToString(),
                    Valor = request.Valor
                };

                idempotencyService.Registrar(idempotencyKey, response);

                return CreatedAtAction(nameof(ObterPix), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPix(Guid id)
        {
            // Simulação (sem banco ainda)
            var response = new PixResponseDto
            {
                Id = id,
                Tipo = "Imediato",
                Valor = 100,
                Status = "Processado"
            };

            return Ok(response);
        }
    }
}
