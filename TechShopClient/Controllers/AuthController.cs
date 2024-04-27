using Microsoft.AspNetCore.Mvc;
using TechShopClient.Models;
using TechShopClient.Services;

namespace TechShopClient.Controllers
{
    public class AuthController : Controller
    {
        private readonly APIGateway _APIGetway;
        
        public AuthController (APIGateway apiGetway)
        {
            _APIGetway = apiGetway;
        }

        [HttpGet]
        public IActionResult Register()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public IActionResult Register(UserDTO userDTO)
        {
            _APIGetway.Register(userDTO);
            return RedirectToAction("Register");
        }
    }
}
