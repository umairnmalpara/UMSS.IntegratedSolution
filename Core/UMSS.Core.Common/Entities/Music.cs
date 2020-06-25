using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Core.Common.Entities.Base;

namespace UMSS.Core.Common.Entities
{
    public class Music : BaseEntity
    {
        public string Name { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        
    }
}
