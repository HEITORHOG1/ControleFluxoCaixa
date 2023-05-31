using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.DeletarLancamentos;
using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;
using Moq;

namespace ControleFluxoCaixa.TEST
{
    public class RemoverLancamentoHandlerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IRepositoryLancamento> _repositoryLancamentoMock;

        public RemoverLancamentoHandlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _repositoryLancamentoMock = new Mock<IRepositoryLancamento>();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var handler = new RemoverLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            var request = new RemoverLancamentoResquest(Guid.NewGuid())
            {
                Id = Guid.NewGuid()
            };

            var existingLancamento = new Lancamento(DateTime.Now.AddDays(-1), "Lançamento antigo", 50.00m, (TipoLancamento)1)
            {
                Id = request.Id,
                Data = DateTime.Now,
                Descricao = "Lançamento de venda",
                Valor = 100.00m,
                Tipo = 0
            };

            _repositoryLancamentoMock.Setup(m => m.ObterPorId(request.Id))
                .Returns(existingLancamento);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Handle_NullRequest_ReturnsErrorResponse()
        {
            // Arrange
            var handler = new RemoverLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            RemoverLancamentoResquest request = null;

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Notifications);
        }

        [Fact]
        public async Task Handle_NonexistentLancamento_ReturnsErrorResponse()
        {
            // Arrange
            var handler = new RemoverLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            var request = new RemoverLancamentoResquest(Guid.NewGuid())
            {
                Id = Guid.NewGuid()
            };

            _repositoryLancamentoMock.Setup(m => m.ObterPorId(request.Id))
                .Returns((Lancamento)null);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Notifications);
        }
    }
}