using Microsoft.AspNetCore.Mvc;

namespace SiteLivro.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
