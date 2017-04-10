using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services
{
    public interface IStoryService
    {
        Task<List<StoryEntity>> GetStories();
        Task<StoryEntity> GetStoryById(int Id);
        Task<List<StoryEntity>> GetStoriesByUserName(string username);
        Task<StoryEntity> CreateStory(StoryEntity storyEntity);
        Task<StoryEntity> UpdateStory(StoryEntity storyEntity);
    }
}
