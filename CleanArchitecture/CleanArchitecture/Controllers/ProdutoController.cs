using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.Interfaces.Catalogo;
using CleanArchitecture.Application.Model.Catalogo;

namespace CleanArchitecture.Controllers
{
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Todos();

            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDTO produto)
        {
            if (produto == null)
                return BadRequest("É necessário informar os dados do produto");

            var result = await _service.Save(produto);

            return Ok(result);
        }
        
    }
}
