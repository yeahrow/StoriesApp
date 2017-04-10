using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoriesApp.Services.Assembler
{
    public abstract class Assembler<TDto, TEntity> where TEntity : class
    {
        public abstract TEntity DtoToDomainEntity(TDto dto);
        public abstract TDto DomainEntityToDto(TEntity domainEntity);

        public List<TDto> DomainEntitiesToDtos(IEnumerable<TEntity> domainEntityList)
        {
            List<TDto> dtos = Activator.CreateInstance<List<TDto>>();
            foreach (TEntity domainEntity in domainEntityList)
            {
                dtos.Add(DomainEntityToDto(domainEntity));
            }
            return dtos;
        }
        

        public List<TEntity> DtosToDomainEntities(IEnumerable<TDto> dtoList)
        {
            List<TEntity> domainEntities = Activator.CreateInstance<List<TEntity>>();
            foreach (TDto dto in dtoList)
            {
                domainEntities.Add(DtoToDomainEntity(dto));
            }
            return domainEntities;
        }
    }
}
