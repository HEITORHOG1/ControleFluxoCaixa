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

        /// <summary>
        /// Adiciona um novo lançamento.
        /// </summary>
        /// <param name="request">Dados do lançamento a ser adicionado.</param>
        /// <returns>O resultado da operação de adição do lançamento.</returns>
        [HttpPost]
        [Route("api/Lancamento/AdicionarLancamento")]
        public async Task<IActionResult> AdicionarLancamento([FromBody] AdicionarLancamentoRequest request)
        {
            try
            {
                // Envia a solicitação de adição do lançamento ao mediador para processamento
                var response = await _mediator.Send(request, CancellationToken.None);

                // Retorna o resultado da operação
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar lançamento");

                // Em caso de erro, retorna uma resposta HTTP 400 Bad Request com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os lançamentos.
        /// </summary>
        /// <returns>Os lançamentos encontrados.</returns>
        [HttpGet]
        [Route("api/Lancamento/ListarLancamento")]
        public async Task<IActionResult> ListarLancamento()
        {
            try
            {
                // Cria a solicitação para listar os lançamentos
                var request = new ListarLancamentoRequest();

                // Envia a solicitação ao mediador para processamento
                var result = await _mediator.Send(request, CancellationToken.None);

                // Retorna os lançamentos encontrados
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar lançamentos");

                // Em caso de erro, retorna uma resposta HTTP 404 Not Found com a mensagem de erro
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Altera um lançamento existente.
        /// </summary>
        /// <param name="request">Dados do lançamento a ser alterado.</param>
        /// <returns>O resultado da operação de alteração do lançamento.</returns>
        [HttpPut]
        [Route("api/Lancamento/AlterarLancamento")]
        public async Task<IActionResult> AlterarLancamento([FromBody] AlterarLancamentoRequest request)
        {
            try
            {
                // Envia a solicitação de alteração do lançamento ao mediador para processamento
                var response = await _mediator.Send(request, CancellationToken.None);

                // Retorna o resultado da operação
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao alterar lançamento");

                // Em caso de erro, retorna uma resposta HTTP 404 Not Found com a mensagem de erro
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Remove um lançamento.
        /// </summary>
        /// <param name="id">Identificador do lançamento a ser removido.</param>
        /// <returns>O resultado da operação de remoção do lançamento.</returns>
        [HttpDelete]
        [Route("api/Lancamento/RemoverLancamento/{id:Guid}")]
        public async Task<IActionResult> RemoverLancamento(Guid id)
        {
            try
            {
                // Cria a solicitação para remover o lançamento com o ID especificado
                var request = new RemoverLancamentoResquest(id);

                // Envia a solicitação ao mediador para processamento
                var result = await _mediator.Send(request, CancellationToken.None);

                // Retorna o resultado da operação
                return await ResponseAsync(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover lançamento");

                // Em caso de erro, retorna uma resposta HTTP 404 Not Found com a mensagem de erro
                return NotFound(ex.Message);
            }
        }


        #endregion
    }
}
