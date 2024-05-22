using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialConnect.Application.NewFolder.IServices;
using SocialConnect.Core.Entities;
using SocialConnect.Web.Models.ViewModels;
using BenchmarkDotNet.Attributes;

namespace SocialConnect.Web.Controllers
{
    [MemoryDiagnoser]//, ThreadingDiagnoser]
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
            IMapper mapper,
            ILogger<AuthController> logger
            ) : base(signInManager, userManager, mapper)
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
        public async Task<IActionResult> Registration([FromForm]RegisterViewModel model)
        {
            try
            {
                if (!_signInManager.IsSignedIn(User))
                {
                    if (ModelState.IsValid)
                    {
                        var user = _mapper.Map<User>(model);
                        if (user != null)
                        {
                            user.Email.ToLower();
                            user.EmailConfirmed = true;
                            user.PhoneNumberConfirmed = true;
                            var result = await _userManager.CreateAsync(user, model.PasswordHash);
                            if (result.Succeeded)
                            {
                                //await _signInManager.SignInAsync(user, isPersistent: false);
                                _logger.LogInformation("Account created successfully. Please login to your account.");
                                return RedirectToAction("Login");
                            }
                            else
                            {
                                _logger.LogError("Account can't be created, please try again later.");
                                return View();
                            }
                        }
                        else
                        {
                            _logger.LogError("Please try again later.");
                            return View();
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Fields marked with '*' must be provided.");
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Warning, ex, ex.Message);
                return View();
                //throw;
            }
        }
        #endregion

        #region User Login
        [Benchmark]
        [HttpGet]
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
        public async Task<IActionResult> Login([FromForm] LoginViewModel model, string returnUrl = null)
        {
            try
            {
                ViewData["ReturnURL"] = returnUrl;
                if (ModelState.IsValid)
                {
                    if (!_signInManager.IsSignedIn(User))
                    {
                        var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
                        if (user != null)
                        {
                            var result = await _signInManager
                                .PasswordSignInAsync(
                                user,
                                model.Password,
                                model.RememberMe, 
                                lockoutOnFailure: false);
                            if (result.Succeeded)
                            {
                                _logger.LogInformation("Redirecting to Feeds.");
                                return RedirectToAction(nameof(FeedController.Index), "Feed");
                            }
                            else
                            {
                                if (result.IsLockedOut || result.IsNotAllowed)
                                {
                                    _logger.LogCritical("Account is locked.");
                                    return View();
                                }
                                else
                                {
                                    _logger.LogError("Account is locked.");
                                    return View();
                                }
                            }
                        }
                        else
                        {
                            _logger.LogWarning("Invalid email or password.");
                            return View();
                        }
                    }
                    else
                    {
                        _logger.LogInformation("User is already loggedIn.");
                        return RedirectToAction(nameof(FeedController.Index), "Feed");
                    }
                }
                else
                {
                    _logger.LogWarning("Email and password are required.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, ex.Message);
                return View();
                //throw;
            }
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
