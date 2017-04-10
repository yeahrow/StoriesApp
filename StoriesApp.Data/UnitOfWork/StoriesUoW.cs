using StoriesApp.Data.DataAccess;
using StoriesApp.Data.DataAccess.Repositories;
using StoriesApp.Data.DataAccess.Repositories.EF;
using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Data.UnitOfWork
{
    public class StoriesUoW<TContext> : IStoriesUoW, IDisposable where TContext : StoriesDBContext, new()
    {
        private StoriesDBContext StoriesContext { get; }

        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;

        public StoriesUoW() : this(new TContext()) { }

        public StoriesUoW(TContext context)
        {
            StoriesContext = context;

            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }

        public IStoriesRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IStoriesEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IStoriesRepository<TEntity>;

            var repository = new StoriesRepository<TEntity>(StoriesContext);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        
        public async Task<bool> CommitAsync()
        {
            try
            {
                if ((await StoriesContext.SaveChangesAsync()) > 0)
                {
                    return true;
                }
            }
            catch (DbEntityValidationException e)
            {
                // log
                throw;
            }
            catch (Exception e)
            {
                // log
                throw;
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
                foreach (var disposableRepository in _repositories.Select(repository => repository.Value as IDisposable))
                {
                    disposableRepository?.Dispose();
                }
                StoriesContext.Dispose();
            }

            _disposed = true;
        }
    }
}
