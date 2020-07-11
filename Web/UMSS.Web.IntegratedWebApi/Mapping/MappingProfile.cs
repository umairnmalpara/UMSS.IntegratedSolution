using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UMSS.Music.Entity;
using UMSS.Web.IntegratedWebApi.Resources;

namespace UMSS.Web.IntegratedWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<UMSS.Music.Entity.Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();

            // Resource to Domain
            CreateMap<MusicResource, UMSS.Music.Entity.Music>();
            CreateMap<ArtistResource, Artist>();
            CreateMap<SaveMusicResource, UMSS.Music.Entity.Music>();
            CreateMap<SaveArtistResource, Artist>();
        }
    }
}
