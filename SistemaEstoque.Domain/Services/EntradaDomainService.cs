using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Domain.Services
{
    public class EntradaDomainService : IEntradaDomainService
    {
        private readonly IEntradaRepository _entradaRepository;

        public EntradaDomainService(IEntradaRepository entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

        public void CadastrarEntrada(Entrada entrada)
        {
           if (entrada == null)
            {
                throw new Exception("O sistema não pode cadastrar entrada de mercadoria vazia.");
            }
            _entradaRepository.Create(entrada);
        }

        public void AtualizarEntrada(Entrada entrada)
        {
            if (entrada.IdMercadoria == null)
            {
                throw new Exception("O sistema não encontrou a entrada, verifique o nome.");
            }
            _entradaRepository.Update(entrada);
        }

        public void ExcluirEntrada(Guid idEntrada)
        {
            if (_entradaRepository.GetById(idEntrada) == null)
            {
                throw new Exception("O sistema não encontrou a entrada, verifique o id.");
            }
            _entradaRepository.Delete(_entradaRepository.GetById(idEntrada));
        }

        public List<Entrada> ConsultarEntradas()
        {
            if (_entradaRepository.GetAll() == null)
            {
                throw new Exception("O sistema não encontrou entrada no banco de dados.");
            }
            return _entradaRepository.GetAll();
        }       

        public Entrada ObterEntrada(Guid idEntrada)
        {
            if (_entradaRepository.GetById(idEntrada) == null)
            {
                throw new Exception("O sistema não encontrou a entrada, verifique o id.");
            }
            return _entradaRepository.GetById(idEntrada);
        }

        public Entrada ObterNome(string nome)
        {
            if (_entradaRepository.GetByNome(nome) == null)
            {
                return null;
            }
            return _entradaRepository.GetByNome(nome);
        }

       
    }
}
