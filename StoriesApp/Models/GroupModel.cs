using StoriesApp.Services.Models;
using StoriesApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoriesApp.Models
{
    public class GroupModel : BaseEntityMapperViewModel<GroupEntity, GroupModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}