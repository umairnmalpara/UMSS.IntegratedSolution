using System;
using System.Collections.Generic;
using System.Text;

namespace UMSS.Core.Generic.Common.Entities.Base
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
