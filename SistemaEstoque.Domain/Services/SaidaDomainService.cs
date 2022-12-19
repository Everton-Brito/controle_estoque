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
    public class SaidaDomainService : ISaidaDomainService
    {
        private readonly ISaidaRepository _saidaRepository;

        public SaidaDomainService(ISaidaRepository saidaRepository)
        {
            _saidaRepository = saidaRepository;
        }

        public void CadastrarSaida(Saida saida)
        {
            if (saida == null)
            {
                throw new Exception("O sistema não pode cadastrar saida de mercadoria vazia.");
            }
            _saidaRepository.Create(saida);
        }

        public void AtualizarSaida(Saida saida)
        {
            if (_saidaRepository.GetById(saida.IdSaida) == null)
            {
                throw new Exception("O sistema não encontrou a saida, verifique o id.");
            }
            _saidaRepository.Update(saida);
        }

        public void ExcluirSaida(Guid id)
        {
            if (_saidaRepository.GetById(id) == null)
            {
                throw new Exception("O sistema não encontrou a saida, verifique o id.");
            }
            _saidaRepository.Delete(_saidaRepository.GetById(id));
        }

        public List<Saida> ConsultarSaidas()
        {
            if (_saidaRepository.GetAll() == null)
            {
                throw new Exception("O sistema não encontrou saida no banco de dados.");
            }
            return _saidaRepository.GetAll();   
        }       

        public Saida ObterSaida(Guid idsaida)
        {
            if (_saidaRepository.GetById(idsaida) == null)
            {
                throw new Exception("O sistema não encontrou a saida, verifique o id.");
            }
            return _saidaRepository.GetById(idsaida);
        }

        public Saida ObterNome(string nome)
        {
            if (_saidaRepository.GetByNome(nome) == null)
            {
                return null;
            }
            return _saidaRepository.GetByNome(nome);
        }
    }
}
