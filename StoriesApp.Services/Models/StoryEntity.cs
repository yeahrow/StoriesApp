using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Models
{
    public class StoryEntity
    {
        public int Id { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }        
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public int UserId { get; set; }
        public List<GroupEntity> Groups { get; set; }
        public UserEntity User { get; set; }

    }
}
