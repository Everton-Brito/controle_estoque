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
    public class MercadoriaRepository : IMercadoriaRepository
    {
        public void Create(Mercadoria mercadoria)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Mercadoria.Add(mercadoria);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Mercadoria mercadoria)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(mercadoria).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public void Delete(Mercadoria mercadoria)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Mercadoria.Remove(mercadoria);
                sqlServerContext.SaveChanges();

            }
        }

        public List<Mercadoria> GetAll()
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Mercadoria.OrderByDescending(m => m.Nome).ToList();
            }
        }

        public Mercadoria GetById(Guid idMercadoria)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Mercadoria.FirstOrDefault(m => m.IdMercadoria == idMercadoria);
            }
        }

        public List<Mercadoria> GetMercadorias(string nomeMercadoria)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Mercadoria.Where(m => m.Nome == nomeMercadoria).OrderByDescending(m => m.Nome).ToList();
            }
        }

       
    }
}
