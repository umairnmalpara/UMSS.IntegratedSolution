using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Core.Generic.Common.Models.Base;
using UMSS.Core.Generic.Common.Models.Meta;

namespace UMSS.Core.Generic.Common.Models
{
    public class MusicModel : BaseModel
    {
        public string Name { get; set; }
        public MetaArtistModel Artist { get; set; }
    }
}
