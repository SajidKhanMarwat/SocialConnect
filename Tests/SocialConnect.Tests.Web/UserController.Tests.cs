using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using SocialConnect.Application.DTOs.User;
using SocialConnect.Application.IServices;
using SocialConnect.Application.Services.IServices;
using SocialConnect.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Tests.Web
{
    public class UsersControllerTests
    {
        //private UsersController _usersController;
        //private Mock<IUserService> _usersService;
        //private Mock<ILogsService> _logs;
        ////private Mock<IMemoryCache> _memoryCache;
        //private MemoryCache _memoryCache;
        //public UsersControllerTests()
        //{
        //    _usersService = new Mock<IUserService>();
        //    _logs = new Mock<ILogsService>();
        //    //_memoryCache = new Mock<IMemoryCache>();
        //    _memoryCache = new MemoryCache(new MemoryCacheOptions());
        //    _usersController = new UsersController(_usersService.Object, _logs.Object, _memoryCache /*_memoryCache.Object*/);
        //}

        //[Fact]
        //public async Task IndexTest()
        //{
        //    //Arrange
        //    //Act
        //    var result = await _usersController.Index();
        //    //Assert
        //    Assert.IsType<ViewResult>(result);
        //}
        //[Fact]
        //public async Task UserById_WithValidId_ReturnsUserDTO()
        //{
        //    //Arrange
        //    int userId = 3;
        //    var userDTO = new UserDTO( userId, "John", "test@gmail.com" );
        //    _usersService.Setup(u => u.GetUserById(userId)).ReturnsAsync(userDTO);
            
        //    //Act
        //    var result = await _usersController.UserById(userId);
            
        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(userId, result.Id);
        //    Assert.Equal("John", result.Name);
        //}
        //[Fact]
        //public async Task UserById_WithZeroId()
        //{
        //    //Arrange
        //    var userDto = new UserDTO(0, "Sajid", "sajid@gmail.com");
        //    _usersService.Setup(u => u.GetUserById(0)).ReturnsAsync(userDto);

        //    //Act
        //    var result = await _usersController.UserById(0);

        //    //Assert
        //    Assert.True(result == null);
        //}
    }
}
