using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Entities;

namespace SocialConnect.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Internal Variables
        internal readonly IMapper _mapper;
        internal UserManager<User> _userManager;
        internal SignInManager<User> _signInManager;
        #endregion

        #region Constructor
        public BaseController(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion

        #region Login Method
        //[HttpPost]
        //public virtual async Task<IActionResult> Login([FromForm] LoginViewModel login, string returnUrl = null)
        //{
        //    ViewData["ReturnURL"] = returnUrl;
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            return await RedirectToLocal(returnUrl);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //        }
        //        return View();
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        #endregion

        #region Delete User
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                var user = await _userManager.Users.Where(u => u.Id == id).FirstOrDefaultAsync();                
                if (user != null)
                {
                    user.IsDeleted = true;
                    var result = await _userManager.DeleteAsync(user);
                    return result.Succeeded
                        ? new JsonResult(result)
                        {
                            Value = result,
                            StatusCode = StatusCodes.Status202Accepted
                        } : new JsonResult(result)
                        {
                            Value = result,
                            StatusCode = StatusCodes.Status303SeeOther
                        };
                }
                else
                {
                    return new JsonResult("Invalid id")
                    {
                        Value = "Invalid id.",
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region LogOut Current User
        [HttpGet]
        protected async Task<bool> LogOut()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
                return true;
            }
            return false;
        }
        #endregion

        #region Redirect To Local URL
        protected async Task<IActionResult> RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) ? Redirect(returnUrl) : RedirectToAction(nameof(HomeController.Index), "Home");
        }
        #endregion
    }
}
