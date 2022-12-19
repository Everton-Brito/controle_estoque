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
    public class EntradaRepository : IEntradaRepository
    {
        public void Create(Entrada entrada)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entrada.Add(entrada);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Entrada entrada)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(entrada).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }       

        public void Delete(Entrada entrada)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entrada.Remove(entrada);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Entrada> GetAll()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Entrada.OrderByDescending(e => e.DataHora).ToList();
            }
        }

        public Entrada GetById(Guid idEntrada)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Entrada.FirstOrDefault(e => e.IdEntrada == idEntrada);
            }
        }

        public Entrada GetByNome(string nome)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Entrada.FirstOrDefault(e => e.Mercadoria.Nome == nome);
            }
        }

       
    }
}
