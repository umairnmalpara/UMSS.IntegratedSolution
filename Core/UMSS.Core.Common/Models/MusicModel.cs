using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Core.Common.Models.Base;
using UMSS.Core.Common.Models.Meta;

namespace UMSS.Core.Common.Models
{
    public class MusicModel : BaseModel
    {
        public string Name { get; set; }
        public MetaArtistModel Artist { get; set; }
    }
}
