using System;
using System.Collections.Generic;
using System.Text;

namespace UMSS.Core.Common.Models.Base
{
    public abstract class BaseModel : IModel
    {
        public int Id { get; set; }
    }
}
