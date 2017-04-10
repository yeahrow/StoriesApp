using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Data.DataAccess.Repositories.EF.Stories
{
    [Table("Users")]
    public class User : IStoriesEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Index]
        public int GroupId { get; set; }
        
        public virtual ICollection<Story> Stories { get; set; }
    }
}
