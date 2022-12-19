using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Mvc.Models;

namespace SistemaEstoque.Mvc.Controllers
{
    public class EntradasController : Controller
    {
        private readonly IEntradaDomainService _entradaDomainService;
        private readonly ISaidaDomainService _saidaDomainService;
        private readonly IMercadoriaDomainService _mercadoriaDomainService;

        public EntradasController(IEntradaDomainService entradaDomainService, IMercadoriaDomainService mercadoriaDomainService, ISaidaDomainService saidaDomainService = null)
        {
            _entradaDomainService = entradaDomainService;
            _mercadoriaDomainService = mercadoriaDomainService;
            _saidaDomainService = saidaDomainService;
        }

        public IActionResult Cadastro()
        {            
            return ModelInicial();
        }

        [HttpPost]
        public IActionResult Cadastro(EntradaCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entrada = new Entrada();
                    var idMercadoria = _mercadoriaDomainService.NomeMercadoria(model.Nome);
                    var nome = _entradaDomainService.ObterNome(model.Nome);
                    
                    foreach (var item in idMercadoria)
                    {
                        entrada.IdMercadoria = item.IdMercadoria;
                    }                        

                    if (nome != null)
                    {
                        entrada.IdEntrada = nome.IdEntrada;
                        entrada.DataHora = nome.DataHora;
                        var num1 = int.Parse(model.Quantidade);
                        var num2 = Convert.ToInt32(nome.Quantidade);
                        entrada.Quantidade = num1 + num2;
                        entrada.Local = model.Local;
                        entrada.IdMercadoria = entrada.IdMercadoria;

                        _entradaDomainService.AtualizarEntrada(entrada);

                        TempData["MensagemSucesso"] = "Mercadoria cadastrada com sucesso.";

                        ModelInicial();
                    }
                    else if(nome == null)
                    {
                        entrada.IdEntrada = Guid.NewGuid();
                        entrada.Quantidade = int.Parse(model.Quantidade);
                        entrada.DataHora = DateTime.Now;
                        entrada.Local = model.Local;
                        entrada.IdMercadoria = entrada.IdMercadoria;
                        _entradaDomainService.CadastrarEntrada(entrada);

                        TempData["MensagemSucesso"] = "Entrada de Mercadoria cadastrada com sucesso.";

                        ModelInicial();
                    }
                   
                   
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }else
            {
                TempData["MensagemErro"] = "Não pode cadastar entrada com campo vazio.";

                return RedirectToAction("Cadastro");
            }
            return View();
        }    

       
        public IActionResult Consulta()
        {
            var lista = new List<EntradaConsultaModel>();
            try
            {         
                var entradas = _entradaDomainService.ConsultarEntradas();

                if (entradas == null)
                {
                    TempData["MensagemErro"] = "Lista esta Vazia";                   
                }
                else
                {
                    foreach (var item in entradas)
                    {
                        var model = new EntradaConsultaModel();
                        var NomeMercadoria = _mercadoriaDomainService.ObterMercadoria(item.IdMercadoria);                     

                        model.IdEntrada = item.IdEntrada;
                        model.Nome = NomeMercadoria.Nome; 
                        model.Quantidade = item.Quantidade;
                        model.DataHora = item.DataHora;
                        model.Local = item.Local;                                           

                        lista.Add(model);
                    }
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
            var model = new EntradaEdicaoModel();

            try
            {
                var entrada = _entradaDomainService.ObterEntrada(id);
                model.Mercadorias = new List<SelectListItem>();

                var mercadoria = _mercadoriaDomainService.ConsultarMercadorias();

                foreach (var item in mercadoria)
                {
                    model.Nome = item.Nome;
                    model.Mercadorias.Add(new SelectListItem { Text = model.Nome, Value = model.Nome.ToString() });
                }

                model.IdEntrada = entrada.IdEntrada;
                model.Quantidade = entrada.Quantidade.ToString();
                model.DataHora = entrada.DataHora;
                model.Local = entrada.Local;

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(EntradaEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entrada = new Entrada();
                    var idMercadoria = _mercadoriaDomainService.NomeMercadoria(model.Nome);

                    foreach (var item in idMercadoria)
                    {
                        entrada.IdMercadoria = item.IdMercadoria;
                    }
                    entrada.IdEntrada = model.IdEntrada;
                    entrada.Quantidade = int.Parse(model.Quantidade);
                    entrada.DataHora = DateTime.Now;
                    entrada.Local = model.Local;
                    entrada.IdMercadoria = entrada.IdMercadoria;

                    _entradaDomainService.AtualizarEntrada(entrada);

                    TempData["MensagemSucesso"] = "Mercadoria Atualizada com sucesso.";


                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return RedirectToAction("Consulta");
        }


        public IActionResult Exclusao(Guid id)
        {
            try
            {
                _entradaDomainService.ExcluirEntrada(id);
                TempData["MensagemSucesso"] = "Entrada excluida com sucesso";

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return RedirectToAction("Consulta");
        }

        public ViewResult ModelInicial()
        {
            var models = new EntradaCadastroModel();
            models.Mercadorias = new List<SelectListItem>();

            var mercadoria = _mercadoriaDomainService.ConsultarMercadorias();

            foreach (var item in mercadoria)
            {

                models.Nome = item.Nome;

                models.Mercadorias.Add(new SelectListItem { Text = models.Nome, Value = models.Nome.ToString() });

            }
            return View(models);
        }
    }
}
