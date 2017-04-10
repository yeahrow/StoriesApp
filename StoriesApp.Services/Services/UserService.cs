using StoriesApp.Data.DataAccess;
using StoriesApp.Data.DataAccess.Repositories.EF;
using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using StoriesApp.Data.UnitOfWork;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IStoriesUoW _storiesUoW;
        private readonly IStoriesRepository<User> _userRepository;
        private readonly IStoriesRepository<Story> _storyRepository;
        private readonly IStoriesRepository<Group> _groupRepository;

        private bool _disposed;

        public UserService()
        {
            _storiesUoW = new StoriesUoW<StoriesDBContext>();

            _userRepository = _storiesUoW.GetRepository<User>();
            _storyRepository = _storiesUoW.GetRepository<Story>();
            _groupRepository = _storiesUoW.GetRepository<Group>();
        }

        public async Task<bool> CheckUserCredentials(UserEntity user)
        {
            var _userDto = await _userRepository.GetAll(u => u.Password == user.Password && u.Name == u.Name).FirstOrDefaultAsync();

            if (_userDto != null)
            {
                return true;
            }
            return false;
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
