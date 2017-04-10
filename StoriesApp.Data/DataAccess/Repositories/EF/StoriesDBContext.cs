using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Data.DataAccess.Repositories.EF
{
    public class StoriesDBContext: DbContext
    {
        public StoriesDBContext()
            : base("name=StoriesConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<StoryGroup> StoryGroups { get; set; }
    }
}
