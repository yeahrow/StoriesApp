using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Assembler
{
    class StoryAssembler : Assembler<StoryEntity, Story>
    {
        public override StoryEntity DomainEntityToDto(Story story)
        {
            if (story == null) return null;

            var storyEntity = new StoryEntity
            {
                Id = story.Id,
                Content = story.Content,
                Description = story.Description,
                PostedOn = story.PostedOn,
                Title = story.Title,
                UserId = story.UserId
            };

            if (story.StoryGroups != null)
            {
                var groupAssembler = new GroupAssembler();
                storyEntity.Groups = groupAssembler.DomainEntitiesToDtos(story.StoryGroups.Select(m=>m.Group));
            }

            if (story.User != null)
            {
                var userAssembler = new UserAssembler();
                storyEntity.User = userAssembler.DomainEntityToDto(story.User);
            }

            return storyEntity;
        }

        public override Story DtoToDomainEntity(StoryEntity dto)
        {
            if (dto == null) return null;

            var story = new Story
            {
                Id = dto.Id,
                Content = dto.Content,
                Description = dto.Description,
                PostedOn = dto.PostedOn,
                Title = dto.Title,
                UserId = dto.UserId
            };

            if (dto.Groups != null)
            {
                story.StoryGroups = dto.Groups.Select(g=> new StoryGroup { GroupId = g.Id }).ToList();
            }

            return story;
        }
    }
}
