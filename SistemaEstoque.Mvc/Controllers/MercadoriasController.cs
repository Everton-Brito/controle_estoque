using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Mvc.Models;

namespace SistemaEstoque.Mvc.Controllers
{
    public class MercadoriasController : Controller
    {
        private readonly IMercadoriaDomainService _mercadoriaDomainService;

        public MercadoriasController(IMercadoriaDomainService mercadoriaDomainService)
        {
            _mercadoriaDomainService = mercadoriaDomainService;
        }

        public IActionResult Cadastro( )
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(MercadoriasCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mercadoria = new Mercadoria
                    {
                        IdMercadoria = Guid.NewGuid(),                        
                        Nome = model.Nome,
                        Registro = model.Registro,
                        Fabricante = model.Fabricante,
                        Tipo = model.Tipo,
                        Descricao = model.Descricao
                    };

                    _mercadoriaDomainService.CadastrarMercadoria(mercadoria);
                    TempData["MensagemSucesso"] = $"Mercadoria {mercadoria.Nome}, cadastrada com sucesso";

                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros no preenchimento do formulário de cadastro,por favor verifique.";
            }

            return View();
        }

        public IActionResult Consulta()
        {
            var lista = new List<MercadoriasConsultaModel>();
            try
            {
                var mercadorias = _mercadoriaDomainService.ConsultarMercadorias();

                foreach (var item in mercadorias)
                {
                    var model = new MercadoriasConsultaModel();
                    model.IdMercadoria = item.IdMercadoria;
                    model.Nome = item.Nome;
                    model.Registro = item.Registro;
                    model.Fabricante = item.Fabricante;
                    model.Tipo = item.Tipo;
                    model.Descricao = item.Descricao;

                    lista.Add(model);
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View(lista);
        }

        public IActionResult Edicao(Guid id)
        {
            var model = new MercadoriaEdicaoModel();
            try
            {
                var mercadoria = _mercadoriaDomainService.ObterMercadoria(id);             

                model.IdMercadoria = mercadoria.IdMercadoria;
                model.Nome = mercadoria.Nome;
                model.Registro = mercadoria.Registro;
                model.Fabricante = mercadoria.Fabricante;
                model.Tipo = mercadoria.Tipo;
                model.Descricao = mercadoria.Descricao;

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(MercadoriaEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mercadoria = new Mercadoria();                   

                    mercadoria.IdMercadoria = model.IdMercadoria;
                    mercadoria.Nome = model.Nome;
                    mercadoria.Registro = model.Registro;
                    mercadoria.Fabricante = model.Fabricante;
                    mercadoria.Tipo = model.Tipo;
                    mercadoria.Descricao = model.Descricao;

                    _mercadoriaDomainService.AtualizarMercadoria(mercadoria);

                    TempData["MensagemSucesso"] = $"Mercadoria {mercadoria.Nome}, atualizada com sucesso";
                }
                catch(Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
            try
            {
                _mercadoriaDomainService.ExcluirMercadoria(id);
                TempData["MensagemSucesso"] = "Mercadoria excluida com sucesso.";


            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;

            }
            return RedirectToAction("Consulta");
        }

        
    }
}
