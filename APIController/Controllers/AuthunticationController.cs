using ApplicationServices.SmartMarket;
using Domain.SmartMarket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIController.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class AuthunticationController : ControllerBase
    {
        AuthOperations _authOperatios;

        public AuthunticationController(AuthOperations authOperatios)
        {
            _authOperatios = authOperatios;
        }

        [HttpGet]
        public bool Authuntication(string email, string password)
        {
            return _authOperatios.Authanticate(email, password);
        }

        [HttpPost]
        public bool Register(Users users)
        {
          
            return _authOperatios.RegisterUser(users);
        }

        [HttpGet]
        public List<Users> GetUsers()
        {
            return _authOperatios.GetUsers();
        }
    }
}
