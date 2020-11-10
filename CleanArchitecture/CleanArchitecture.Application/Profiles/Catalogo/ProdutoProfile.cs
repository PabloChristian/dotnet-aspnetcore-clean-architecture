using AutoMapper;
using CleanArchitecture.Application.Model.Catalogo;
using CleanArchitecture.Core.Entities.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Profiles.Catalogo
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDTO>();
        }
    }
}
