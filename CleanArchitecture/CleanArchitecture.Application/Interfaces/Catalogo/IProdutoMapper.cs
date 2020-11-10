using CleanArchitecture.Application.Model.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces.Catalogo
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> Save(ProdutoDTO entity);
        Task<IEnumerable<ProdutoDTO>> Todos();
    }
}
