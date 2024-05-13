using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialConnect.Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SocialConnect.Web.Controllers
{
    [Authorize]
    public class FeedController : BaseController
    {
        public FeedController(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper) : base(signInManager, userManager, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
