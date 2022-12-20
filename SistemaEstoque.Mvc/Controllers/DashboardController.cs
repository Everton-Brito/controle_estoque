using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Mvc.Models;

namespace SistemaEstoque.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IEntradaDomainService _entradaDomainService;
        private readonly ISaidaDomainService _saidaDomainService;
        private readonly IRelatorioDomainService _relatorioDomainService;

        public DashboardController(IEntradaDomainService entradaDomainService, ISaidaDomainService saidaDomainService, IRelatorioDomainService relatorioDomainService)
        {
            _entradaDomainService = entradaDomainService;
            _saidaDomainService = saidaDomainService;
            _relatorioDomainService = relatorioDomainService;
        }

        public IActionResult Dashboard()
        {
            try
            {
                var entradas = _entradaDomainService.ConsultarEntradas();
                var saidas = _saidaDomainService.ConsultarSaidas();

                TempData["TotalEntradas"] = entradas.Sum(e => e.Quantidade);
                TempData["TotalSaidas"] = saidas.Sum(s => s.Quantidade);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View();
        }

        public IActionResult Relatorio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Relatorio(DashboardRelatorioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entradas = _entradaDomainService.ConsultarEntradas();
                    var saidas = _saidaDomainService.ConsultarSaidas();

                    var nomeArquivo = $"relatorio_{DateTime.Now.ToString()}.pdf";
                    var tipoArquivo = "application/pdf";
                    byte[] arquivo = _relatorioDomainService.GerarPdf(entradas, saidas);

                    return File(arquivo, tipoArquivo, nomeArquivo);
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }else
            {
                TempData["MensagemErro"] = "Ocorreram erros no preenchimento do formulário de relatorios, por favor verifique.";

            }
            return View();
        }
    }
}
