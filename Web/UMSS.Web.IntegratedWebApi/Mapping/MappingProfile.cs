using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Web.IntegratedWebApi.Resources;

namespace UMSS.Web.IntegratedWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();

            // Resource to Domain
            CreateMap<MusicResource, Music>();
            CreateMap<ArtistResource, Artist>();
            CreateMap<SaveMusicResource, Music>();
            CreateMap<SaveArtistResource, Artist>();
        }
    }
}
