using StoriesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace StoriesApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/group")]
    public class GroupController : ApiController
    {
        private readonly IStoryService _storyService;
        private readonly IGroupService _groupService;

        public GroupController(IStoryService storyService, IGroupService groupService)
        {
            _storyService = storyService;
            _groupService = groupService;
        }


        [HttpGet]        
        public async Task<IHttpActionResult> GetGroups()
        {
            var groups = await _groupService.GetGroups("stories;users");
            var g = groups.Select(m => new { Id = m.Id, Name = m.Name }).ToList();
            return Ok(groups);
        }
    }
}