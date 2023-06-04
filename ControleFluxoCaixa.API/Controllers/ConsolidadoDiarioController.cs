using ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ConsolidadoDiario;
using ControleFluxoCaixa.DOMAIN.Model;
using ControleFluxoCaixa.INFRA.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFluxoCaixa.API.Controllers
{
    public class ConsolidadoDiarioController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LancamentoController> _logger;
        public ConsolidadoDiarioController(IMediator mediator, IUnitOfWork unitOfWork, ILogger<LancamentoController> logger) : base(unitOfWork)
        {
            _mediator = mediator;
            _logger = logger;   
        }

        /// <summary>
        /// Obtém o consolidado diário de lançamentos para uma data específica.
        /// </summary>
        /// <param name="data">Data para a qual se deseja obter o consolidado diário.</param>
        /// <returns>O consolidado diário de lançamentos.</returns>
        [HttpGet]
        [Route("api/Consolidado/ListarConsolidadoDiario/{data}")]
        public async Task<IActionResult> ListarConsolidadoDiario(DateTime data)
        {
            try
            {
                _logger.LogInformation("ListarConsolidadoDiario: {@data}", data);

                // Cria a solicitação para obter o consolidado diário de lançamentos
                var request = new ConsolidadoDiarioRequest(data.Date);

                // Envia a solicitação ao mediador para processamento
                var result = await _mediator.Send(request, CancellationToken.None);

                // Retorna a resposta HTTP 200 OK juntamente com o resultado retornado
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar consolidado diário");

                // Em caso de erro, retorna uma resposta HTTP 500 Internal Server Error com uma mensagem genérica
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao listar o consolidado diário");
            }
        }

    }
}
