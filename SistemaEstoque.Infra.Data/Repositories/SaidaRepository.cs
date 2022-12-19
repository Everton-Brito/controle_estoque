using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstoque.Infra.Data.Repositories
{
    public class SaidaRepository : ISaidaRepository
    {
        public void Create(Saida saida)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Saida.Add(saida);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Saida saida)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(saida).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Saida saida)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Saida.Remove(saida);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Saida> GetAll()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Saida.OrderByDescending(s => s.DataHora).ToList();
            }
        }

        public Saida GetById(Guid idSaida)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Saida.FirstOrDefault(s => s.IdSaida == idSaida);
            }
        }

        public Saida GetByNome(string nome)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Saida.FirstOrDefault(s => s.Mercadoria.Nome == nome);
            }
        }
    }
}
