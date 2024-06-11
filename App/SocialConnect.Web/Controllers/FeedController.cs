using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialConnect.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using SocialConnect.Application.IServices;
using SocialConnect.Application.DTOs.User;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using Newtonsoft.Json;
using SocialConnect.Web.Models.ViewModels;

namespace SocialConnect.Web.Controllers
{
    //[Authorize(Roles = "User")]
    [Authorize]
    public class FeedController : BaseController
    {
        #region
        private IUserService _userService;
        #endregion
        public FeedController(SignInManager<User> signInManager, 
            UserManager<User> userManager, 
            IServiceProvider serviceProvider, 
            IMapper mapper,
            IUserService userService) : 
            base(signInManager, userManager, serviceProvider, mapper)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
        public async Task<IActionResult> Profile()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> SearchUser(string search)
        {
            search.ToLower();
            var isFound = await _userService.FindUserByNameAsync(search);

            //return JsonConvert.SerializeObject(isFound);
            FriendsSearchVM dt = new FriendsSearchVM();
            dt.SearchedUsers = isFound.ToList();
            return Json(dt);
        }
    }
}
