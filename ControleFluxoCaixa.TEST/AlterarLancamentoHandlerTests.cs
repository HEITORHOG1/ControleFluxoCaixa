using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AlterarLancamentos;
using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;
using Moq;

namespace ControleFluxoCaixa.TEST
{
    public class AlterarLancamentoHandlerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IRepositoryLancamento> _repositoryLancamentoMock;

        public AlterarLancamentoHandlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _repositoryLancamentoMock = new Mock<IRepositoryLancamento>();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var handler = new AlterarLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            var request = new AlterarLancamentoRequest
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                Descricao = "Lançamento de venda",
                Valor = 100.00m,
                Tipo = 0
            };

            var existingLancamento = new Lancamento(DateTime.Now.AddDays(-1),"Lançamento antigo", 50.00m, (TipoLancamento)1)
            {
                Id = request.Id,
                Data = DateTime.Now.AddDays(-1),
                Descricao = "Lançamento antigo",
                Valor = 50.00m,
                Tipo = (TipoLancamento)1
            };

            _repositoryLancamentoMock.Setup(m => m.Listar())
                .Returns(new[] { existingLancamento }.AsQueryable());

            _repositoryLancamentoMock.Setup(m => m.Editar(It.IsAny<Lancamento>()))
                .Returns((Lancamento lancamento) => lancamento);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Handle_NullRequest_ReturnsErrorResponse()
        {
            // Arrange
            var handler = new AlterarLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            AlterarLancamentoRequest request = null;

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
            var handler = new AlterarLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            var request = new AlterarLancamentoRequest
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                Descricao = "Lançamento de venda",
                Valor = 100.00m,
                Tipo = 0
            };

            _repositoryLancamentoMock.Setup(m => m.Listar())
                .Returns(Enumerable.Empty<Lancamento>().AsQueryable());

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Notifications);
        }
    }
}