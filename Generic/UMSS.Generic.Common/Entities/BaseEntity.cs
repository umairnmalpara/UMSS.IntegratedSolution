using System;
using System.Collections.Generic;
using System.Text;

namespace UMSS.Generic.Common.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
