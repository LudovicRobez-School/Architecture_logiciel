using System;
using System.Collections.Generic;
using System.Text;
using ApiLibrary.Core.Attributes;

namespace ApiLibrary.Core.Entities
{
    public class BaseModel<T> : BaseEntity
    {
        [NoModified]
        public T Id { get; set; }
    }
}
