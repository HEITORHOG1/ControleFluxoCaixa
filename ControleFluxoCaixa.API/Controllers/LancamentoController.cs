using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AdicionarLancamentos;
using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AlterarLancamentos;
using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.DeletarLancamentos;
using ControleFluxoCaixa.CQRS.QUERIES.Lancamentos.ListarLancamentos;
using ControleFluxoCaixa.INFRA.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFluxoCaixa.API.Controllers
{
    public class LancamentoController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LancamentoController> _logger;

        public LancamentoController(IMediator mediator, IUnitOfWork unitOfWork, ILogger<LancamentoController> logger) : base(unitOfWork)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Lancamento

        [HttpPost]
        [Route("api/Lancamento/AdicionarLancamento")]
        public async Task<IActionResult> AdicionarLancamento([FromBody] AdicionarLancamentoRequest request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar lançamento");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Lancamento/ListarLancamento")]
        public async Task<IActionResult> ListarLancamento()
        {
            try
            {
                var request = new ListarLancamentoRequest();
                var result = await _mediator.Send(request, CancellationToken.None);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar lançamentos");
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/Lancamento/AlterarLancamento")]
        public async Task<IActionResult> AlterarLancamento([FromBody] AlterarLancamentoRequest request)
        {
            try
            {
                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao alterar lançamento");
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/Lancamento/RemoverLancamento/{id:Guid}")]
        public async Task<IActionResult> RemoverLancamento(Guid id)
        {
            try
            {
                var request = new RemoverLancamentoResquest(id);
                var result = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover lançamento");
                return NotFound(ex.Message);
            }
        }

        #endregion
    }
}
