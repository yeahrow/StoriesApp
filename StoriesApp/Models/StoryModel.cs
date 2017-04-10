using StoriesApp.Services.Models;
using StoriesApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesApp.Models
{
    public class StoryModel : BaseEntityMapperViewModel<StoryEntity, StoryModel>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public UserModel User { get; set; }
        public List<GroupModel> Groups { get; set; }
    }

    public class StoryPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int[] GroupIds { get; set; }
    }
}