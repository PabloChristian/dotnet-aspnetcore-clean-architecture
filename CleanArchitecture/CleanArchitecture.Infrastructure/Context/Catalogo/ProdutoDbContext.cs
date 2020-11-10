using CleanArchitecture.Core.Entities.Catalogo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Context.Catalogo
{
    public class ProdutoDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options)
        {

        }
    }
}
