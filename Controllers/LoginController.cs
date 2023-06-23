using Login.Models;
using Login.Repositories;
using Login.Repositories.Interfaces;
using Login.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Login.Controllers
{
    public class LoginController : Controller
    {

        public readonly IUserRepository _repository;

        public LoginController(IUserRepository repository)
        {

            _repository = repository;

        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = new User();
            var token = "";

            if (model.Username != null & model.Password != null)
            {
                user = await _repository.GetUserAsync(model.Username, model.Password);
            }
            else
            {
                return NotFound(new { message = "Informar usuário e senha válidos" });
            }

            // Verifica se o usuário existe
            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
            else
            {
                token = TokenService.GenerateToken(user);
                SaveCookie(user.Username, user.Role, token);
            }

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        private void SaveCookie(string user, string role, string token) 
        {
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddHours(2);
            cookieOptions.Path = "/";
            Response.Cookies.Append("User", user, cookieOptions);
            Response.Cookies.Append("Role", role, cookieOptions);
            Response.Cookies.Append("Token", token, cookieOptions);
        }
    }
}
