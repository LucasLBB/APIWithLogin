using Login.Models;
using Login.Repositories.Interfaces;
using Login.Services;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class CatalogController : Controller
    {

        public readonly IProductRepository _repository;

        public CatalogController(IProductRepository repository)
        {

            _repository = repository;

        }

        [HttpGet]
        [Route("catalog")]
        public async Task<ActionResult<dynamic>> GetCatalog()
        {
            // Recupera o usuário
            var products = _repository.GetProduct();

            // Verifica se o usuário existe
            if (products.Count == 0)
                return NotFound(new { message = "USem produtos para exibir" });

            // Gera o Token
            //var token = TokenService.GenerateToken(products);

            // Oculta a senha
            //user.Password = "";

            // Retorna os dados
            return products;
        }
    }
}
