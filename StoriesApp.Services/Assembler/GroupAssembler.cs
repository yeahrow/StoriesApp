using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Assembler
{
    class GroupAssembler : Assembler<GroupEntity, Group>
    {
        public override GroupEntity DomainEntityToDto(Group group)
        {
            if (group == null) return null;

            var groupEntity = new GroupEntity
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
            };
            
            if (group.StoryGroups != null)
            {
                //groupEntity.Stories = group.StoryGroups.Select(m => new StoryEntity { Id = m.Story.Id }).ToList();
                groupEntity.StoriesCount = group.StoryGroups.Count();
            }

            return groupEntity;
        }

        public override Group DtoToDomainEntity(GroupEntity dto)
        {
            if (dto == null) return null;

            var group = new Group
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };

            if (dto.Stories != null)
            {

            }

            return group;
        }
    }
}
