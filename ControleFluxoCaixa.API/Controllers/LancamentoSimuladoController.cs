using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos;
using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.Simulado.AdicionarLancamentosSimulado;
using ControleFluxoCaixa.INFRA.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFluxoCaixa.API.Controllers
{
    public class LancamentoSimuladoController : Base.ControllerBase
    {
        private readonly ILogger<LancamentoSimuladoController> _logger;
        private readonly LancamentoStore _lancamentoStore;

        public LancamentoSimuladoController(
                                            IUnitOfWork unitOfWork,
                                            ILogger<LancamentoSimuladoController> logger,
                                            LancamentoStore lancamentoStore) : base(unitOfWork)
        {
            _logger = logger;
            _lancamentoStore = lancamentoStore;
        }



        /// <summary>
        /// Adiciona um novo lançamento simulado.
        /// </summary>
        /// <param name="request">Dados do lançamento simulado a ser adicionado.</param>
        /// <returns>Uma resposta HTTP indicando o resultado da operação.</returns>
        [HttpPost]
        [Route("api/LancamentoSimulado/AdicionarLancamentoSimulado")]
        [ProducesResponseType(StatusCodes.Status200OK)] // Indica que o método retorna 200 OK em caso de sucesso
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Indica que o método retorna 400 Bad Request em caso de erro
        public async Task<IActionResult> AdicionarLancamentoSimulado([FromBody] AdicionarLancamentoSimuladoRequest request)
        {
            try
            {
                await _lancamentoStore.AddAsync(request.LancamentoSimulacao);

                // Retorna uma resposta HTTP 200 OK em caso de sucesso
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar lançamento simulado");

                // Em caso de erro, retorna uma resposta HTTP 400 Bad Request com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os lançamentos simulados.
        /// </summary>
        /// <returns>Os lançamentos simulados encontrados.</returns>
        [HttpGet]
        [Route("api/LancamentoSimulado/ListarLancamentoSimulado")]
        public async Task<IActionResult> ListarLancamentoSimulado()
        {
            try
            {
                var lancamentos = await _lancamentoStore.GetAllAsync();

                // Retorna os lançamentos simulados encontrados
                return Ok(lancamentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar lançamentos simulados");

                // Em caso de erro, retorna uma resposta HTTP 404 Not Found com a mensagem de erro
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Lista o consolidado simulado diário para uma data específica.
        /// </summary>
        /// <param name="data">A data para a qual o consolidado simulado diário deve ser gerado.</param>
        /// <returns>O consolidado simulado diário para a data especificada.</returns>
        [HttpGet]
        [Route("api/Consolidado/ListarConsolidadoSimuladoDiario/{data}")]
        public async Task<IActionResult> ListarConsolidadoSimuladoDiario(DateTime data)
        {
            try
            {
                var lancamentos = await _lancamentoStore.GerarRelatorio(data);

                // Retorna o consolidado simulado diário
                return Ok(lancamentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar consolidado simulado diário");

                // Em caso de erro, retorna uma resposta HTTP 404 Not Found com a mensagem de erro
                return NotFound(ex.Message);
            }
        }

    }
}
