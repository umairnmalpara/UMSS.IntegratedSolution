using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Generic.Common.Entities;

namespace UMSS.Music.Entity
{
    public class Music : BaseEntity
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        
    }
}
