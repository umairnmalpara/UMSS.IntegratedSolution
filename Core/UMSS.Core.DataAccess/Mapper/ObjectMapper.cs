using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UMSS.Core.Common.Entities;
using UMSS.Core.Common.Models;
using UMSS.Core.Common.Models.Meta;

namespace UMSS.Core.DataAccess.Mapper
{
    // The best implementation of AutoMapper for class libraries -> https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<EntityModelMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class EntityModelMapper : Profile
    {
        public EntityModelMapper()
        {
            CreateMap<Artist, ArtistModel>().ReverseMap();
            CreateMap<Artist, MetaArtistModel>().ReverseMap();

            CreateMap<Music, MusicModel>()
                .ForMember(model => model.Artist,mus => { mus.AllowNull(); mus.MapFrom(a => a.Artist); })
                .ReverseMap();
        }
    }
}
