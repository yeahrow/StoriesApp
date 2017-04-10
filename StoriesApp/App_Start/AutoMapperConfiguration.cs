using AutoMapper;
using StoriesApp.Models;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesApp.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<StoryEntity, StoryModel>();
            Mapper.CreateMap<GroupEntity, GroupModel>();
            Mapper.CreateMap<UserEntity, UserModel>();
        }
    }
}