﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SocialConnect.Application.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using SocialConnect.Core.Entities;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using SocialConnect.Application.IServices;

namespace SocialConnect.Web.Controllers
{
    [Authorize, MemoryDiagnoser]
    public class UsersController : BaseController
    {
        #region Fields
        private IUserService _userService;
        private ILogsService _logger;
        private IMemoryCache _memoryCache;
        private IUserService object1;
        private ILogsService object2;
        private MemoryCache memoryCache;
        #endregion
        public UsersController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IUserService userService,
            IServiceProvider serviceProvider,
            ILogsService logger,
        IMemoryCache memoryCache,
            IMapper mapper) : base(signInManager, userManager, serviceProvider, mapper)
        {
            _userService = userService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [Benchmark]
        public async Task<IActionResult> Profile()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var loggedUserId = _signInManager.UserManager.GetUserId(User);
                if (loggedUserId != null)
                {
                    var user = await _signInManager.UserManager.FindByIdAsync(loggedUserId);
                    return user != null ? View(user) : View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Index()
        {
            return View();
            //try
            //{
            //    var result = await UserById(3);
            //    return View(result);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }
        //public async Task<UserDTO> UserById([FromQuery] int id)
        //{
        //    if (id != 0 && id.ToString() != string.Empty)
        //    {
        //        if (!_memoryCache.TryGetValue(id, out UserDTO? user) && _memoryCache != null)
        //        {
        //            try
        //            {
        //                var singleUser = await _userService.GetUserById(id);
        //                if (singleUser != null)
        //                {
        //                    _memoryCache.Set(id, singleUser,
        //                    new MemoryCacheEntryOptions()
        //                    {
        //                        AbsoluteExpiration = DateTime.Now.AddSeconds(50),
        //                        Priority = CacheItemPriority.High,
        //                        SlidingExpiration = TimeSpan.FromSeconds(20)
        //                    });
        //                }
        //                await _logger.SaveLogs($"User info retrieved with id = {id}");
        //                return singleUser;
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //        }
        //        else
        //        {
        //            return user;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
