using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Entities;
using SocialConnect.Web.Models.Enums;
using SocialConnect.Web.Models.ViewModels;

namespace SocialConnect.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Internal Variables
        internal readonly IMapper _mapper;
        internal UserManager<User> _userManager;
        internal SignInManager<User> _signInManager;
        internal IServiceProvider _serviceProvider;
        #endregion

        #region Constructor
        public BaseController(SignInManager<User> signInManager, 
            UserManager<User> userManager, 
            IServiceProvider serviceProvider, 
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }
        #endregion

        #region Login Method
        public virtual async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    try
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            //return await RedirectToLocal(returnUrl);
                            return RedirectToAction(nameof(FeedController.Index), "Feed");
                        }
                        else if (result.IsLockedOut)
                        {
                            ModelState.AddModelError(string.Empty, "User account locked out.");
                        }
                        else if (result.IsNotAllowed)
                        {
                            ModelState.AddModelError(string.Empty, "User is not allowed to sign in.");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        }
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError(string.Empty, "Unexpected error occoured. Try again...");
                    }
                }
                else
                {
                    //Logger here
                    return View(model);
                }
            }

            return View(model);
        }
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
