using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DomainObject;
using DomainObject.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using Service.Controllers.Abstract;
using Service.Views;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers.Api.v1
{
    [Route("api/v1/[controller]")]
    public class TodoItemController : AbstractController<TodoItem, ITodoItemHandler>
    {
        public TodoItemController(ITodoItemHandler handler) : base(handler)
        {
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TodoItemView> Get() 
        {
            return _handler.Retrieve().Select(c => new TodoItemView(c));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoItemView Get(Guid id)
        {
            var entity = _handler.Retrieve(id);
            if(entity == null){
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }
            return new TodoItemView(entity);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]TodoItemView value)
        {
            var entity = new TodoItem();
            _handler.Create(value.Hydrate(entity));
        }

        // PUT api/values/Guid
        [HttpPut("{id}")]
        public TodoItemView Put(Guid id, [FromBody]TodoItemView value)
        {
            var entity = _handler.Retrieve(id);
            if (entity == null)
            {
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
            _handler.Delete(id);
        }
    }
}
