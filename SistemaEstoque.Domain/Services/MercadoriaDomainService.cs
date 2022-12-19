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
    public class MercadoriaDomainService : IMercadoriaDomainService
    {
        private readonly IMercadoriaRepository _mercadoriaRepository;

        public MercadoriaDomainService(IMercadoriaRepository mercadoriaRepository)
        {
            _mercadoriaRepository = mercadoriaRepository;
        }

        public void CadastrarMercadoria(Mercadoria mercadoria)
        {
            if (mercadoria == null)
            {
                throw new Exception("O sistema não pode cadastrar Mercadoria vazia.");
            }
            _mercadoriaRepository.Create(mercadoria);
        }

        public void AtualizarMercadoria(Mercadoria mercadoria)
        {
            if (_mercadoriaRepository.GetById(mercadoria.IdMercadoria) == null)
            {
                throw new Exception("O sistema não encontrou a Mercadoria, verifique o id.");

            }
            _mercadoriaRepository.Update(mercadoria);
        }

        public void ExcluirMercadoria(Guid idMercadoria)
        {
            if (_mercadoriaRepository.GetById(idMercadoria) == null)
            {
                throw new Exception("O sistema não encontrou a Mercadoria, verifique o id.");

            }
            _mercadoriaRepository.Delete(_mercadoriaRepository.GetById(idMercadoria));
        }

        public List<Mercadoria> ConsultarMercadorias()
        {
            if (_mercadoriaRepository.GetAll() == null)
            {
                throw new Exception("O sistema não encontrou a Mercadoria.");
            }
            return _mercadoriaRepository.GetAll();
        }       

        public List<Mercadoria> NomeMercadoria(string nomeMercadoria)
        {
            if (_mercadoriaRepository.GetMercadorias(nomeMercadoria) == null)
            {
                throw new Exception("O sistema não encontrou a Mercadoria, verifique o nome.");

            }
          return _mercadoriaRepository.GetMercadorias(nomeMercadoria);
        }

        public Mercadoria ObterMercadoria(Guid idMercadoria)
        {
            if (_mercadoriaRepository.GetById(idMercadoria) == null)
            {
                throw new Exception("O sistema não encontrou a Mercadoria, verifique o id.");

            }
            return _mercadoriaRepository.GetById(idMercadoria);
        }
    }
}
