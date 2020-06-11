using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLibrary.Core.Attributes;

namespace ApiLibrary.Core.Entities
{
    public abstract class BaseEntity
    {
        [NoModified]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [NoModified]
        public DateTime? DeletedAt { get; set; }
    }
}
