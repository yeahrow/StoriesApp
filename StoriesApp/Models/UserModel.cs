using StoriesApp.Services.Models;
using StoriesApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesApp.Models
{
    public class UserModel : BaseEntityMapperViewModel<UserEntity, UserModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}