using StoriesApp.Models;
using StoriesApp.Services;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace StoriesApp.Controllers
{
    [RoutePrefix("api/story")]
    [Authorize]
    public class StoryController : ApiController
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetStory(int? id)
        {
            if (id == null) return BadRequest();

            var story = await _storyService.GetStoryById(id.Value);

            var storiesModel =  StoryModel.MapFromEntity(story);

            return Ok(storiesModel);
        }

        [HttpGet]
        [Route("mystories")]
        public async Task<IHttpActionResult> GetUserStories()
        {
            var stories = await _storyService.GetStoriesByUserName(User.Identity.Name);

            var storiesModel = stories.Select(s => StoryModel.MapFromEntity(s));

            return Ok(storiesModel);
        }



        [HttpPost]
        public async Task<IHttpActionResult> CreateStory([FromBody]StoryPostModel model)
        {
            var story = await _storyService.CreateStory(new StoryEntity
            {
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                UserId = 1,
                PostedOn = DateTime.Now,
                Groups = model.GroupIds.Select(g => new GroupEntity { Id = g }).ToList()
            });

            if(story==null) return Json(new { success = false, message = "Something went wrong!" });

            return Ok(new { success = true, message = "Successfully added!" });
        }

        [HttpPatch]
        public async Task<IHttpActionResult> UpdateStory([FromBody]StoryPostModel model)
        {
            var story = await _storyService.UpdateStory(new StoryEntity
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                UserId = 1,
                PostedOn = DateTime.Now,
                Groups = model.GroupIds.Select(g => new GroupEntity { Id = g }).ToList()
            });
            if (story == null) return Json(new { success = false, message = "Something went wrong!" });

            return Ok(new { success = true, message = "Successfully updated!" });
        }

    }
}