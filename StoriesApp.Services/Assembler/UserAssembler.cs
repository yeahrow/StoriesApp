using StoriesApp.Data.DataAccess.Repositories.EF.Stories;
using StoriesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Assembler
{
    class UserAssembler : Assembler<UserEntity, User>
    {
        public override UserEntity DomainEntityToDto(User user)
        {
            if (user == null) return null;

            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name
            };

            if (user.Stories != null)
            {
                // todo
            }

            return userEntity;
        }

        public override User DtoToDomainEntity(UserEntity dto)
        {
            if (dto == null) return null;

            var user = new User
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return user;
        }
    }
}
