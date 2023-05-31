using ControleFluxoCaixa.CQRS.COMANDS.Lancamentos.AdicionarLancamentos;
using ControleFluxoCaixa.DOMAIN.Interfaces;
using ControleFluxoCaixa.DOMAIN.Model;
using MediatR;
using Moq;

namespace ControleFluxoCaixa.TEST
{
    public class AdicionarLancamentoHandlerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IRepositoryLancamento> _repositoryLancamentoMock;

        public AdicionarLancamentoHandlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _repositoryLancamentoMock = new Mock<IRepositoryLancamento>();
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var handler = new AdicionarLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            var request = new AdicionarLancamentoRequest
            {
                Data = DateTime.Now,
                descrição = "Lançamento de venda",
                Valor = 100.00m,
                Tipo = 0
            };

            _repositoryLancamentoMock.Setup(m => m.Adicionar(It.IsAny<Lancamento>()))
                .Returns((Lancamento lancamento) => lancamento);

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Handle_NullRequest_ReturnsErrorResponse()
        {
            // Arrange
            var handler = new AdicionarLancamentoHandler(_mediatorMock.Object, _repositoryLancamentoMock.Object);
            AdicionarLancamentoRequest request = null;

            // Act
            var response = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.NotEmpty(response.Notifications);
        }
    }
}