using Microsoft.AspNetCore.Mvc;

namespace SocialConnect.Web.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
