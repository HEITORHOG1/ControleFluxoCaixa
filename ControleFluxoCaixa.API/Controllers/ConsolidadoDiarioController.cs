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

        [HttpGet]
        [Route("api/Consolidado/ListarConsolidadoDiario/{data}")]
        public async Task<IActionResult> ListarConsolidadoDiario(string data)
        {
            try
            {
                _logger.LogInformation("ListarConsolidadoDiario: {@data}", data);
                var request = new ConsolidadoDiarioRequest(Convert.ToDateTime(data));
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar consolidado diário");
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao listar o consolidado diário");
            }
        }
    }
}
