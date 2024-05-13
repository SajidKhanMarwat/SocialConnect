using Microsoft.AspNetCore.Identity;
using SocialConnect.Application.AutoMapper;
using SocialConnect.Core.Entities;
using SocialConnect.Web.Models.ViewModels;

namespace SocialConnect.Web.AutoMapper
{
    public class Mapping : MappingProfile
    {
        public Mapping() : base()
        {
            CreateMap<RegisterViewModel, User>();
            CreateMap<RegisterViewModel, IdentityUser>();
        }
    }
}
