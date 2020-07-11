using System;
using System.Collections.Generic;
using System.Text;

namespace UMSS.Generic.Common.Models
{
    public abstract class BaseModel : IModel
    {
        public int Id { get; set; }
    }
}
