using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Data;
using ApiLibrary.Core.Entities;
using Catalog.API.Models;

namespace Catalog.API.Controllers
{ 
    [ApiVersion("1")]
    public class CategoriesController : BaseController<Category,int,CatalogDbContext>
    {

        public CategoriesController(CatalogDbContext context) : base(context)
        {
            
        }

        public override Task<ActionResult> DeleteItemAsync([FromRoute] int id)
        {
            return base.DeleteItemAsync(id);
        }

        public override Task<ActionResult<Category>> GetItemByIdAsync([FromRoute] object id)
        {
            return base.GetItemByIdAsync(id);
        }

        public override Task<ActionResult> PostItemAsync([FromBody] Category item)
        {
            return base.PostItemAsync(item);
        }

        public override Task<ActionResult> PutItemAsync([FromBody] Category item, [FromRoute] int id)
        {
            return base.PutItemAsync(item, id);
        }
    }
}
