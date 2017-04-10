using StoriesApp.Data.DataAccess;
using StoriesApp.Data.DataAccess.Repositories.EF;
using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using StoriesApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StoriesApp.Services.Assembler;
using StoriesApp.Services.Models;

namespace StoriesApp.Services.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoriesUoW _storiesUoW;
        private readonly IStoriesRepository<User> _userRepository;
        private readonly IStoriesRepository<Story> _storyRepository;
        private readonly IStoriesRepository<Group> _groupRepository;

        private bool _disposed;

        public StoryService()
        {
            _storiesUoW = new StoriesUoW<StoriesDBContext>();

            _userRepository = _storiesUoW.GetRepository<User>();
            _storyRepository = _storiesUoW.GetRepository<Story>();
            _groupRepository = _storiesUoW.GetRepository<Group>();
        }

        public async Task<StoryEntity> GetStoryById(int Id)
        {
            var story = await _storyRepository
                .GetAll(m=>m.Id == Id)
                .Include(s => s.StoryGroups)
                .Include(s => s.User)
                .FirstOrDefaultAsync();

            var storyAssembler = new StoryAssembler();
            var storyEntity = storyAssembler.DomainEntityToDto(story);

            return storyEntity;
        }

        public async Task<List<StoryEntity>> GetStories()
        {
            var stories = await _storyRepository
                .GetAll()
                .Include(s => s.StoryGroups)
                .Include(s => s.StoryGroups.Select(sg => sg.Group))
                .Include(s => s.User)
                .ToListAsync();

            var storyAssembler = new StoryAssembler();
            var storyEntities = storyAssembler.DomainEntitiesToDtos(stories);

            return storyEntities;
        }

        public async Task<List<StoryEntity>> GetStoriesByUserName(string username)
        {
            var user = await _userRepository
                .GetAll(m => m.Name == username)
                .Include(s => s.Stories)
                .FirstOrDefaultAsync();

            if (user == null) return null;

            var storyAssembler = new StoryAssembler();
            var storyEntities = storyAssembler.DomainEntitiesToDtos(user.Stories);

            return storyEntities;
        }

        public async Task<List<StoryEntity>> GetUserStories(int userId)
        {
            var user = await _userRepository
                .GetAll(u=>u.Id == userId)
                .Include(s => s.Stories)
                .FirstOrDefaultAsync();
            if (user == null) return null;

            var storyAssembler = new StoryAssembler();
            var storyEntities = storyAssembler.DomainEntitiesToDtos(user.Stories);

            return storyEntities;
        }

        public async Task<List<StoryEntity>> GetGroupStories(int groupId)
        {
            var group = await _groupRepository
                .GetAll(u => u.Id == groupId)
                .Include(s => s.StoryGroups)
                .Include(s => s.StoryGroups.Select(sg => sg.Story))
                .FirstOrDefaultAsync();

            if (group == null) return null;

            var storyAssembler = new StoryAssembler();
            var storyEntities = storyAssembler.DomainEntitiesToDtos(group.StoryGroups.Select(sg => sg.Story));

            return storyEntities;
        }

        public async Task<StoryEntity> CreateStory(StoryEntity storyEntity)
        {
           
            var storyAssembler = new StoryAssembler();
            var de = storyAssembler.DtoToDomainEntity(storyEntity);
                
            _storyRepository.Create(de);

            if (!(await _storiesUoW.CommitAsync())) return null;
            
            return storyAssembler.DomainEntityToDto(de);
        }

        public async Task<StoryEntity> UpdateStory(StoryEntity storyEntity)
        {
            try
            {
                var db_story = await _storyRepository.GetAll(m => m.Id == storyEntity.Id).FirstOrDefaultAsync();
                db_story.Title = storyEntity.Title;
                db_story.Content = storyEntity.Content;
                db_story.Description = storyEntity.Description;

                foreach (var sg in db_story.StoryGroups.ToList())
                {
                    db_story.StoryGroups.Remove(sg);
                }

                db_story.StoryGroups = storyEntity.Groups.Select(g => new StoryGroup { GroupId = g.Id }).ToList();


                if (!(await _storiesUoW.CommitAsync())) return null;

                var storyAssembler = new StoryAssembler();

                return storyAssembler.DomainEntityToDto(db_story);
            }
            catch(Exception ex)
            {
                return null;
            }
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                var disposableStoriesUnitOfWork = _storiesUoW as IDisposable;
                disposableStoriesUnitOfWork?.Dispose();
            }

            _disposed = true;
        }
    }
}
