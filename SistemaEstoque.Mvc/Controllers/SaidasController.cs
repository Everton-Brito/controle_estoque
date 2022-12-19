using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Mvc.Models;

namespace SistemaEstoque.Mvc.Controllers
{
    public class SaidasController : Controller
    {
        private readonly ISaidaDomainService _saidaDomainService;
        private readonly IMercadoriaDomainService _mercadoriaDomainService;
        private readonly IEntradaDomainService _entradaDomainService;

        public SaidasController(ISaidaDomainService saidaDomainService, IMercadoriaDomainService mercadoriaDomainService, IEntradaDomainService entradaDomainService)
        {
            _saidaDomainService = saidaDomainService;
            _mercadoriaDomainService = mercadoriaDomainService;
            _entradaDomainService = entradaDomainService;
        }

        public IActionResult Cadastro()
        {

            return ModelInicial();
        }

        [HttpPost]
        public IActionResult Cadastro(SaidaCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var saida = new Saida();
                    var idMercadoria = _mercadoriaDomainService.NomeMercadoria(model.Nome);
                    var nome = _saidaDomainService.ObterNome(model.Nome);
                    var quantidadeEntrada = _entradaDomainService.ObterNome(model.Nome);

                    foreach (var item in idMercadoria)
                    {
                        saida.IdMercadoria = item.IdMercadoria;
                    }
                    
                        if (nome != null)
                        {
                            int somaQuantidade = int.Parse(model.Quantidade) + nome.Quantidade;

                            if (somaQuantidade > quantidadeEntrada.Quantidade)
                            {
                                TempData["MensagemErro"] = "Não pode cadastrar saida com quantidade maior que a entrada.";
                                ModelInicial();
                            }
                            else
                            {
                                saida.IdSaida = nome.IdSaida;
                                saida.DataHora = nome.DataHora;
                                var num1 = int.Parse(model.Quantidade);
                                var num2 = Convert.ToInt32(nome.Quantidade);
                                saida.Quantidade = num1 + num2;
                                saida.Local = model.Local;
                                saida.IdMercadoria = saida.IdMercadoria;

                                _saidaDomainService.AtualizarSaida(saida);

                                TempData["MensagemSucesso"] = "Saída de Mercadoria cadastrada com sucesso.";

                                ModelInicial();
                            }                            

                        }
                        else if (nome == null)
                        {
                            if (int.Parse(model.Quantidade) > quantidadeEntrada.Quantidade)
                            {
                                TempData["MensagemErro"] = "Não pode cadastar saida com quantidade maior que a entrada.";

                                ModelInicial();
                            }else

                            {
                                saida.IdSaida = Guid.NewGuid();
                                saida.Quantidade = int.Parse(model.Quantidade);
                                saida.DataHora = DateTime.Now;
                                saida.Local = model.Local;
                                saida.IdMercadoria = saida.IdMercadoria;

                                _saidaDomainService.CadastrarSaida(saida);

                                TempData["MensagemSucesso"] = "Saída de Mercadoria cadastrada com sucesso.";

                                ModelInicial();
                            }
                           
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
            var lista = new List<SaidaConsultaModel>();
            try
            {
                var saidas = _saidaDomainService.ConsultarSaidas();

                if (saidas == null)
                {
                    TempData["MensagemErro"] = "Lista esta Vazia";
                }
                else
                {
                    foreach (var item in saidas)
                    {
                        var model = new SaidaConsultaModel();
                        var NomeMercadoria = _mercadoriaDomainService.ObterMercadoria(item.IdMercadoria);

                        model.Nome = NomeMercadoria.Nome;
                        model.IdSaida = item.IdSaida;
                        model.Quantidade = Convert.ToString(item.Quantidade);                  
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
            var model = new SaidaEdicaoModel();
            try
            {
               
                var saida = _saidaDomainService.ObterSaida(id);
                var nome = _mercadoriaDomainService.ObterMercadoria(saida.IdMercadoria);

                model.Nome = nome.Nome;
                model.IdSaida = saida.IdSaida;
                model.Quantidade = saida.Quantidade.ToString();
                model.DataHora = saida.DataHora;
                model.Local = saida.Local;
                model.IdMercadoria = saida.IdMercadoria;

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(SaidaEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var quantidadeEntrada = _entradaDomainService.ObterNome(model.Nome);

                    var saida = new Saida();
                    if (int.Parse(model.Quantidade) > quantidadeEntrada.Quantidade)
                    {
                        TempData["MensagemErro"] = "Não pode cadastrar saida com quantidade maior que a entrada.";
                        ModelInicial();
                    }else
                    {
                        saida.IdSaida = model.IdSaida;
                        saida.Quantidade = int.Parse(model.Quantidade);
                        saida.DataHora = DateTime.Now;
                        saida.Local = model.Local;
                        saida.IdMercadoria = model.IdMercadoria;

                        _saidaDomainService.AtualizarSaida(saida);

                        TempData["MensagemSucesso"] = "Saida Atualizada com sucesso.";
                    }
                    

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
                _saidaDomainService.ExcluirSaida(id);
                TempData["MensagemSucesso"] = "Saida excluida com sucesso";

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return RedirectToAction("Consulta");
        }

        public ViewResult ModelInicial()
        {
            var model = new SaidaCadastroModel();
            model.Mercadorias = new List<SelectListItem>();

            var mercadoria = _mercadoriaDomainService.ConsultarMercadorias();

            foreach (var item in mercadoria)
            {

                model.Nome = item.Nome;

                model.Mercadorias.Add(new SelectListItem { Text = model.Nome, Value = model.Nome.ToString() });

            }
            return View(model);
        }
    }
}
