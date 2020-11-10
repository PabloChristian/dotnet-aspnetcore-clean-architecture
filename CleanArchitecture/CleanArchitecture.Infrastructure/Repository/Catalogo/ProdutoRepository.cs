using CleanArchitecture.Core.Entities.Catalogo;
using CleanArchitecture.Core.Interfaces.Catalogo;
using CleanArchitecture.Infrastructure.Context.Catalogo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repository.Catalogo
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoDbContext _context;
        public ProdutoRepository(ProdutoDbContext context)
        {
            _context = context;
        }
        public async Task<Produto> Save(Produto entity)
        {
            _context.Produtos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Produto>> Todos()
        {
            return await _context.Produtos.ToListAsync();
        }
    }
}
