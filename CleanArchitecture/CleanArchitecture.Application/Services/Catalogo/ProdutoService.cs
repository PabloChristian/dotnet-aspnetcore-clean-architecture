using AutoMapper;
using CleanArchitecture.Application.Interfaces.Catalogo;
using CleanArchitecture.Application.Model.Catalogo;
using CleanArchitecture.Core.Entities.Catalogo;
using CleanArchitecture.Core.Interfaces.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mapper.Catalogo
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProdutoDTO>> Todos()
        {
            var produtos = await _repository.Todos();
            var result = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
            return result;
        }
        public async Task<ProdutoDTO> Save(ProdutoDTO entity)
        {
            var produto = _mapper.Map<Produto>(entity);
            var produtoSalvo = await _repository.Save(produto);
            return _mapper.Map<ProdutoDTO>(produtoSalvo);
        }
    }
}
