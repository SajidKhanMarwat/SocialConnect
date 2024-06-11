using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialConnect.Application.IServices;
using SocialConnect.Core.Entities;
using SocialConnect.Web.Models.ViewModels;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Authorization;
using SocialConnect.Web.Models.Enums;

namespace SocialConnect.Web.Controllers
{
    [MemoryDiagnoser]//, ThreadingDiagnoser]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        #region Fields
        private IUserService _userServiceContext;
        private ILogger<AuthController> _logger;
        #endregion

        #region Constructor
        public AuthController(
            IUserService userServiceContext,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IServiceProvider serviceProvider,
            IMapper mapper,
            ILogger<AuthController> logger
            ) : base(signInManager, userManager, serviceProvider, mapper)
        {
            _userServiceContext = userServiceContext;
            _logger = logger;
        }
        #endregion

        #region User Registration
        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration([FromForm] RegisterViewModel model)
        {
            try
            {
                if (!_signInManager.IsSignedIn(User))
                {
                    if (ModelState.IsValid)
                    {
                        if (!_userManager.Users.Any(e => e.Email == model.Email || e.UserName == model.UserName))
                        {
                            var user = _mapper.Map<User>(model);
                            user.Email.ToLower();
                            user.UserName.ToLower();
                            user.PhoneNumberConfirmed = true;
                            var result = await _userManager.CreateAsync(user, model.PasswordHash);
                            //return result.Succeeded ? RedirectToAction("Login") : View();
                            if (!result.Succeeded)
                            {
                                ViewBag.Errors = result.Errors;
                                return View(model);
                            }
                            await _userManager.AddToRoleAsync(user, Roles.SocialUser.ToString());
                            //await _signInManager.SignInAsync(user, isPersistent: false);
                            _logger.LogInformation("Account created successfully. Please login to your account.");

                            /*
                             * This where we will send the user a confirmation code to his email.
                             * User will be redirected to Email confirmation page.
                             */

                            return RedirectToAction(nameof(FeedController.Index), "Feed");
                        }
                        _logger.LogError(string.Empty, "User with the provided email already exists. Try login...");
                        ViewData["EmailExists"] = "The provided email and/or Username already exists, try <a href=\"/auth/login\" class=\"alert-link\">Login Here</a>.";
                        return View();
                    }
                    else
                    {
                        _logger.LogWarning("Fields marked with '*' must be provided.");
                        return View(model);
                    }
                }
                else
                {
                    return RedirectToAction(nameof(FeedController.Index), "Feed");
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Warning, ex, ex.Message);
                return BadRequest();
                //throw;
            }
        }
        #endregion

        #region Capturing the Requested URL
        [AllowAnonymous]
        public async Task<IActionResult> RedirectingToLogin()
        {
            // Get the current URL
            var returnUrl = HttpContext.Request.Path + HttpContext.Request.QueryString;

            return RedirectToAction("Login", "Auth", new { returnUrl });
        }
        #endregion

        #region User Login
        [Benchmark]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction(nameof(FeedController.Index), "Feed");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public async override Task<IActionResult> Login([FromForm] LoginViewModel model, string returnUrl = null)
        {
            returnUrl = Request.QueryString.Value;
            return await base.Login(model, returnUrl);
            //try
            //{
            //    ViewData["ReturnURL"] = returnUrl;
            //    if (ModelState.IsValid)
            //    {
            //        if (!_signInManager.IsSignedIn(User))
            //        {
            //            var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
            //            if (user != null)
            //            {
            //                var result = await _signInManager
            //                    .PasswordSignInAsync(
            //                    user,
            //                    model.Password,
            //                    model.RememberMe, 
            //                    lockoutOnFailure: false);
            //                if (result.Succeeded)
            //                {
            //                    _logger.LogInformation("Redirecting to Feeds.");
            //                    return RedirectToAction(nameof(FeedController.Index), "Feed");
            //                }
            //                else
            //                {
            //                    if (result.IsLockedOut || result.IsNotAllowed)
            //                    {
            //                        _logger.LogCritical("Account is locked.");
            //                        return View();
            //                    }
            //                    else
            //                    {
            //                        _logger.LogError("Account is locked.");
            //                        return View();
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                _logger.LogWarning("Invalid email or password.");
            //                return View();
            //            }
            //        }
            //        else
            //        {
            //            _logger.LogInformation("User is already loggedIn.");
            //            return RedirectToAction(nameof(FeedController.Index), "Feed");
            //        }
            //    }
            //    else
            //    {
            //        _logger.LogWarning("Email and password are required.");
            //        return View();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogInformation(ex, ex.Message);
            //    return View();
            //    //throw;
            //}
        }
        #endregion

        #region LogOut
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            bool isLoggedOut = await LogOut();
            return isLoggedOut ? Ok(StatusCodes.Status200OK) : BadRequest(StatusCodes.Status400BadRequest);
        }
        #endregion

        #region Delete User
        //    [HttpGet]
        //    public async Task<IActionResult> Delete()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public async Task<IActionResult> Delete([FromForm]string userId)
        //    {
        //        var result = await base.Delete(userId);
        //        switch (result.StatusCode)
        //        {
        //            case StatusCodes.Status202Accepted: return RedirectToAction("Registration");
        //            case StatusCodes.Status404NotFound: return View();
        //            default: return View();
        //        }
        //        //if (result.StatusCode == StatusCodes.Status202Accepted)
        //        //{
        //        //    return RedirectToAction("Registration");
        //        //}
        //        //else if(result.StatusCode == StatusCodes.Status404NotFound)
        //        //{
        //        //    return View();
        //        //}
        //        //else
        //        //{
        //        //    return View();
        //        //}
        //    }
        #endregion
    }
}
