using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApi.Models;

namespace webApi.Controllers
{
    public class ProdutosController : ApiController
    {
        Produto[] produtos = new Produto[]
        {
            new Produto { Id = 1, Nome = "Tomato Soup", Categoria = "Groceries", Preco = 1 },
            new Produto { Id = 2, Nome = "Yo-yo", Categoria = "Toys", Preco = 3.75M },
            new Produto { Id = 3, Nome = "Hammer", Categoria = "Hardware", Preco = 16.99M }
        };

        public IEnumerable<Produto> GetAllProdutos()
        {
            return produtos;
        }

        public IHttpActionResult GetProduto(int id)
        {
            var produto = produtos.FirstOrDefault((p) => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }
    }
}
