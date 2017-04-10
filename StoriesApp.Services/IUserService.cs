using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services
{
    public interface IUserService
    {
        Task<bool> CheckUserCredentials(UserEntity user);
    }
}
