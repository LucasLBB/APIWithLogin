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

            string cookieValue = Request.Cookies["token"];

            if (cookieValue == null)
            {
                return NotFound(new { message = "Realize o login para acessar o catálogo" });
            }    
            else
            {
                var tokenValidate = TokenService.ValidateToken(cookieValue);
            }
                

            // Recupera os produtos
            var products = _repository.GetProduct();

            // Verifica se possui produtos
            if (products.Count == 0)
                return NotFound(new { message = "Sem produtos para exibir" });

            return products;

        }
    }
}
