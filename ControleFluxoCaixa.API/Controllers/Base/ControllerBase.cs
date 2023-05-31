using ControleFluxoCaixa.DOMAIN.Model;
using ControleFluxoCaixa.INFRA.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace ControleFluxoCaixa.API.Controllers.Base
{
    public class ControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> ResponseAsync(Response response)
        {
            if (!response.Notifications.Any())
            {
                try
                {
                    _unitOfWork.SaveChanges();

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    // Aqui devo logar o erro
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                    //return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return Ok(response);
            }
        }

        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
