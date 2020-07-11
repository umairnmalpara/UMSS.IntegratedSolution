using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UMSS.Generic.Common.Entities;

namespace UMSS.Music.Entity
{
    public class Artist : BaseEntity
    {
        public Artist()
        {
            Musics = new Collection<Music>();
        }

        public string Name { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}