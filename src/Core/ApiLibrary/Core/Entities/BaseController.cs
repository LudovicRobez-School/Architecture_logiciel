using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace ApiLibrary.Core.Entities
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseController<TModel, TKey, TContext> : ControllerBase 
        where TContext : BaseDbContext 
        where TModel : BaseModel<TKey>
    { 
        private readonly TContext _db;

        public BaseController(TContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Object>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult<TModel>> GetItemsAsync()
        {
        
            var items = _db.Set<TModel>().Where(x => x.DeletedAt == null);

            return Ok(await items.ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<Object>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult<TModel>> GetItemByIdAsync([FromRoute] object id)
        {
            var item = await _db.FindAsync<TModel>(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual async Task<ActionResult> PostItemAsync([FromBody]TModel item)
        {
            if (ModelState.IsValid)
            {
                _db.Set<TModel>().Add(item);
                await _db.SaveChangesAsync();
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual async Task<ActionResult> PutItemAsync([FromBody]TModel item, [FromRoute] TKey id)
        {
            if (id.Equals(item.Id))
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _db.Update<TModel>(item);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult> DeleteItemAsync([FromRoute]TKey id)
        {
            var item = await _db.FindAsync<TModel>(id);
            if (item != null)
            {
                _db.Remove<TModel>(item);
                await _db.SaveChangesAsync();
            }
            return NotFound();
        }

    }
}
