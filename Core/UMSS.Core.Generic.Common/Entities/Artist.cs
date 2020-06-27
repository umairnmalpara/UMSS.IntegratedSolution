﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UMSS.Core.Generic.Common.Entities.Base;

namespace UMSS.Core.Generic.Common.Entities
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