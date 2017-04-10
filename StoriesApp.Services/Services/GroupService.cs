using StoriesApp.Data.DataAccess;
using StoriesApp.Data.DataAccess.Repositories.EF;
using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using StoriesApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoriesApp.Services.Models;
using System.Data.Entity;
using StoriesApp.Services.Assembler;

namespace StoriesApp.Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IStoriesUoW _storiesUoW;
        private readonly IStoriesRepository<User> _userRepository;
        private readonly IStoriesRepository<Story> _storyRepository;
        private readonly IStoriesRepository<Group> _groupRepository;

        private bool _disposed;

        public GroupService()
        {
            _storiesUoW = new StoriesUoW<StoriesDBContext>();

            _userRepository = _storiesUoW.GetRepository<User>();
            _storyRepository = _storiesUoW.GetRepository<Story>();
            _groupRepository = _storiesUoW.GetRepository<Group>();
        }


        public async Task<List<GroupEntity>> GetGroups(string include = "")
        {
            var _groups = _groupRepository.GetAll();


            if (include.Split(';').Any(i => i.ToLower() == "stories"))
            {
                _groups.Include(m => m.StoryGroups);
                _groups.Include(m => m.StoryGroups.Select(sg => sg.Story));
            }

            var groups = await _groups.ToListAsync();

            var groupAssembler = new GroupAssembler();
            var groupEntities = groupAssembler.DomainEntitiesToDtos(groups);

            if (include.Split(';').Any(i => i.ToLower() == "users"))
            {
                var groupUsersCount = await _userRepository.GetAll().GroupBy(u => u.GroupId).Select(g => new { GroupId = g.FirstOrDefault().GroupId, Count = g.Count() }).ToListAsync();
                foreach (var guc in groupUsersCount)
                {
                    groupEntities.FirstOrDefault(m => m.Id == guc.GroupId).UsersCount = guc.Count;
                }
            }

            return groupEntities;
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
