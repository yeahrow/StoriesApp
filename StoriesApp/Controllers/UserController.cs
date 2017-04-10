using StoriesApp.Models;
using StoriesApp.Services;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace StoriesApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IStoryService _storyService;
        private readonly IUserService _userService;

        public UserController(IStoryService storyService, IUserService userService)
        {
            _storyService = storyService;
            _userService = userService;
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody]UserLoginViewModel model)
        {
            if (!ModelState.IsValid) return Json(new { success = false, message = "Model state is not valid!" });

            if (await _userService.CheckUserCredentials(new UserEntity { Name = model.Name,Password=model.Password }))
            {
                FormsAuthentication.SetAuthCookie(model.Name, false);

                return Json(new { success = true, message = "Successfully Logged in." });
            }

            return Json(new { success = false, message = "Name or Password is not correct!" });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IHttpActionResult> Logout()
        {
            FormsAuthentication.SignOut();

            return Json(new { success = true, message = "Successfully Logged out." });            
        }
    }
}