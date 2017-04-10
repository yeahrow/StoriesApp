using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<StoryEntity> Stories { get; set; }
    }
}
