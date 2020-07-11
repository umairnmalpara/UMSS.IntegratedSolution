using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Music.Entity;
using UMSS.Music.Model;
using UMSS.Music.Model.Meta;

namespace UMSS.Music.MapperService
{
    public class EntityModelMapper : Profile
    {
        public EntityModelMapper()
        {
            CreateMap<Artist, ArtistModel>().ReverseMap();
            CreateMap<Artist, MetaArtistModel>().ReverseMap();

            CreateMap<UMSS.Music.Entity.Music, MusicModel>()
                .ForMember(model => model.Artist, mus => { mus.AllowNull(); mus.MapFrom(a => a.Artist); })
                .ReverseMap();
        }
    }
}
