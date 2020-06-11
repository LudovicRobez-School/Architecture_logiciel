using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiLibrary.Core.Entities;
using ApiLibrary.Core.Attributes;

namespace Catalog.API.Models
{
    public class Product : BaseModel<int>
    {
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName ="decimal(6,2)")]
        [Required]
        [NoModified]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }

}
