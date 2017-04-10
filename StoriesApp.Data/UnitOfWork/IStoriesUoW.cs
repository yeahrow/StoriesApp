using StoriesApp.Data.DataAccess;
using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Data.UnitOfWork
{
    public interface IStoriesUoW
    {
        IStoriesRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IStoriesEntity;
        Task<bool> CommitAsync();
    }
}
