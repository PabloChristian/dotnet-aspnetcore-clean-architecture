using CleanArchitecture.Core.Entities.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Catalogo
{
    public interface IProdutoRepository
    {
        Task<Produto> Save(Produto entity);
        Task<IEnumerable<Produto>> Todos();
    }
}
