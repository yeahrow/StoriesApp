using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Data.DataAccess.Repositories.EF.Stories
{
    [Table("StoryGroups")]
    public class StoryGroup : IStoriesEntity
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Story")]
        public int StoryId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public virtual Story Story { get; set; }
        public virtual Group Group { get; set; }
    }
}
