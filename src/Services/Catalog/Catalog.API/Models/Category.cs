using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiLibrary.Core.Entities;

namespace Catalog.API.Models
{
    public class Category : BaseModel<int>
    {
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
