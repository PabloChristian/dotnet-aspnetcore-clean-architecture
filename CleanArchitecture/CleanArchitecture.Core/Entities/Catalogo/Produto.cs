using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.Catalogo
{
    public class Produto
    {
        private Guid Id { get; set; }
        private string Nome { get; set; }
        private string Descricao { get; set; }
        private decimal Preco { get; set; }

        public Produto(Guid id,string nome, string descricao, decimal preco)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

    }
}
