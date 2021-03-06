﻿using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Generic.Common.Specifications;

namespace UMSS.Music.Business.Specifications
{
    public sealed class MusicSpecification : BaseSpecification<UMSS.Music.Entity.Music>
    {
        //SearchMusicWithPagination
        public MusicSpecification(int pageNo, int pageSize,int? musicId,int? artistId,string musicName = null,string artistName = null)
        : base
            (a => (!musicId.HasValue || (a.Id == musicId.Value))
             && (!artistId.HasValue || (a.ArtistId == artistId.Value))
             && (string.IsNullOrWhiteSpace(musicName) || (a.Name.Contains(musicName)))
             && (string.IsNullOrWhiteSpace(artistName) || (a.Artist.Name.Contains(artistName)))
            )
        {
            ApplyPaging((pageNo-1) * pageSize, pageSize);
            ApplyOrderByDescending(a => a.Id);
        }

        //GetByArtistId
        public MusicSpecification(int artistId)
            : base(b => b.ArtistId == artistId)
        {
        }
        
    }
    
}
