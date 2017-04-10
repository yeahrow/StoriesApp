using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace StoriesApp.Utilities
{
    public abstract class BaseEntityMapperViewModel<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        static BaseEntityMapperViewModel()
        {
            Mapper.CreateMap<TViewModel, TEntity>();
            Mapper.CreateMap<TEntity, TViewModel>();
        }

        public TEntity MapToEntity()
        {
            return Mapper.Map<TEntity>(CastToDerivedClass(this));
        }

        public static TViewModel MapFromEntity(TEntity model)
        {
            return Mapper.Map<TViewModel>(model);
        }

        private static TViewModel CastToDerivedClass(BaseEntityMapperViewModel<TEntity, TViewModel> baseInstance)
        {
            return Mapper.Map<TViewModel>(baseInstance);
        }

    }
}