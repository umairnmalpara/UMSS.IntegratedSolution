using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Generic.Common.Models;
using UMSS.Music.Model.Meta;

namespace UMSS.Music.Model
{
    public class MusicModel : BaseModel
    {
        public string Name { get; set; }
        public MetaArtistModel Artist { get; set; }
    }
}
