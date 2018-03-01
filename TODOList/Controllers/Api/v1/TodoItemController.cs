using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DomainObject;
using DomainObject.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Controllers.Abstract;
using Service.Views;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers.Api.v1
{
    [Route("api/v1/[controller]")]
    public class TodoItemController : AbstractController<TodoItem, ITodoItemHandler>
    {
        public TodoItemController(ITodoItemHandler handler, ILogger<TodoItemController> logger) : base(handler, logger)
        {
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TodoItemView> Get() 
        {
            _logger.LogInformation("Retrieve List");
            return _handler.Retrieve().Select(c => new TodoItemView(c));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoItemView Get(Guid id)
        {
            _logger.LogInformation("Retrieve Item {ID}", id);
            var entity = _handler.Retrieve(id);
            if(entity == null){
                _logger.LogWarning("Item Id {ID} not found", id);
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }
            return new TodoItemView(entity);
        }

        // POST api/values
        [HttpPost]
        public TodoItemView Post([FromBody]TodoItemView value)
        {
            _logger.LogInformation("Create item");
            var entity = new TodoItem();
            entity = _handler.Create(value.Hydrate(entity));
            if(entity == null){
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }
            Response.StatusCode = (int)HttpStatusCode.Created;
            return new TodoItemView(entity);
        }

        // PUT api/values/Guid
        [HttpPut("{id}")]
        public TodoItemView Put(Guid id, [FromBody]TodoItemView value)
        {
            _logger.LogInformation("Update Item {ID}", id);
            var entity = _handler.Retrieve(id);
            if (entity == null)
            {
                _logger.LogWarning("Item {ID} does not exist yet", id);
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }
            entity = value.Hydrate(entity);
            entity.Id = id;


            entity = _handler.Update(entity);

            return new TodoItemView(entity);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _logger.LogInformation("Delete item {ID}", id);
            _handler.Delete(id);
        }
    }
}
