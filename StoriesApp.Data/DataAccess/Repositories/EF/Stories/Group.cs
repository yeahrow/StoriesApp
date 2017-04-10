using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Data.DataAccess.Repositories.EF.Stories
{
    [Table("Groups")]
    public class Group : IStoriesEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StoryGroup> StoryGroups { get; set; }

    }
}
