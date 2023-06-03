using ControleFluxoCaixa.CQRS.Validacao;
using ControleFluxoCaixa.DOMAIN.Model;
using FluentValidation;

namespace ControleFluxoCaixa.CQRS.COMANDS.Lancamentos
{
    public class LancamentoStore
    {
        private readonly JsonFileService _fileService;
        private List<LancamentoSimulacao> _lancamentos;

        public LancamentoStore(JsonFileService fileService)
        {
            _fileService = fileService;
            _lancamentos = _fileService.ReadFromFileAsync<List<LancamentoSimulacao>>().Result ?? new List<LancamentoSimulacao>();
        }

        public async Task<IEnumerable<LancamentoSimulacao>> GetAllAsync() => _lancamentos;

        public async Task AddAsync(LancamentoSimulacao lancamento)
        {
            var validator = new LancamentoSimulacaoValidator();
            var validationResult = await validator.ValidateAsync(lancamento);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _lancamentos.Add(lancamento);
            await _fileService.WriteToFileAsync(_lancamentos);
        }

        public LancamentoSimulacao GetById(Guid id) => _lancamentos.FirstOrDefault(l => l.Id == id);

        public void Update(LancamentoSimulacao updatedLancamento)
        {
            var validator = new LancamentoSimulacaoValidator();
            var validationResult = validator.Validate(updatedLancamento);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingLancamento = GetById((Guid)updatedLancamento.Id);
            if (existingLancamento != null)
            {
                existingLancamento.Data = updatedLancamento.Data;
                existingLancamento.Descricao = updatedLancamento.Descricao;
                existingLancamento.Valor = updatedLancamento.Valor;
                existingLancamento.Tipo = updatedLancamento.Tipo;
            }
        }

        public void Delete(Guid id)
        {
            var existingLancamento = GetById(id);
            if (existingLancamento == null)
            {
                throw new ValidationException("Lançamento com o ID especificado não foi encontrado.");
            }

            _lancamentos.Remove(existingLancamento);
        }


        public async Task<RelatorioSimulacao> GerarRelatorio(DateTime data)
        {
            var Consolidados = (await _fileService.ReadFromFileAsync<List<LancamentoSimulacao>>())
                .Where(l => l.Data.Date == data)
                .ToList();

            decimal totalCreditos = Consolidados
                .Where(l => l.Tipo == LancamentoSimulacao.TipoLancamentoSimulacao.Credito)
                .Sum(l => l.Valor);

            decimal totalDebitos = Consolidados
                .Where(l => l.Tipo == LancamentoSimulacao.TipoLancamentoSimulacao.Debito)
                .Sum(l => l.Valor);

            decimal saldoAtual = totalCreditos + totalDebitos;

            var relatorio = new RelatorioSimulacao
            {
                TotalCreditos = totalCreditos,
                TotalDebitos = totalDebitos,
                SaldoAtual = saldoAtual,
                Lancamentos = Consolidados,
            };

            return relatorio;
        }
    }

}
