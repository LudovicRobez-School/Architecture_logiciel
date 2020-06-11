using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Models;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Data;
using ApiLibrary.Core.Entities;

namespace Catalog.API.Controllers
{
    [ApiVersion("1")]
    public class ProductsController : BaseController<Product, int, CatalogDbContext>
    {

        public ProductsController(CatalogDbContext db) : base (db)
        {
           
        }

        public override Task<ActionResult> DeleteItemAsync([FromRoute] int id)
        {
            return base.DeleteItemAsync(id);
        }

        public override Task<ActionResult<Product>> GetItemsAsync()
        {
            return base.GetItemsAsync();
        }

        public override Task<ActionResult<Product>> GetItemByIdAsync([FromRoute] object id)
        {
            return base.GetItemByIdAsync(id);
        }

        public override Task<ActionResult> PostItemAsync([FromBody] Product item)
        {
            return base.PostItemAsync(item);
        }

        public override Task<ActionResult> PutItemAsync([FromBody] Product item, [FromRoute] int id)
        {
            return base.PutItemAsync(item, id);
        }
    }
}