using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Models
{
    public class GroupEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StoryEntity> Stories { get; set; }
        public int UsersCount { get; set; }
        public int StoriesCount { get; set; }

    }
}
