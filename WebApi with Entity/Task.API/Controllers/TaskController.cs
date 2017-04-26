using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task.Domain.Abstract;
using Task.Domain.Concrete;
using Task.Domain.Entity;

namespace Task.API.Controllers
{
    public class TaskController : ApiController
    {
        private ITaskRepository _repository = new EFTaskRepository(new EFDbContext());

        public List<Task.Domain.Entity.Task> Get(int? id = null)
        {
            var tasks = new List<Task.Domain.Entity.Task>();
            if (id.HasValue)
            {
                Task.Domain.Entity.Task task = _repository.Get(id.Value);
                tasks.Add(task);
            }
            else
            {
                tasks = _repository.GetAll();
            }
            return tasks;
        }
        public IHttpActionResult Post([FromBody] Task.Domain.Entity.Task task)
        {
            if(_repository.IsTaskExist(task.Name))
            {
                return BadRequest("This is task have in DataBase");
            }

            var toCreate = new List<Task.Domain.Entity.Task>();
            toCreate.Add(_repository.Create(task));
            
            return Ok<List<Task.Domain.Entity.Task>>(toCreate);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IHttpActionResult Put(int id, [FromBody]Task.Domain.Entity.Task task)
        {
            var toUpdate = _repository.GetAll().Find(u => u.Id == id);
          //  toUpdate.Id = task.Id;
            toUpdate.Name = task.Name;
            toUpdate.IsCompleted = task.IsCompleted;

            _repository.Update(toUpdate);

            return Ok<Task.Domain.Entity.Task>(toUpdate);
        }
        //    Task.Domain.Entity.Task oldTask = _repository.Tasks.Where(o => o.Id == id).FirstOrDefault();
        //    if (oldTask == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //    try
        //    {
        //        oldTask.Name = task.Name;
        //        oldTask.IsCompleted = task.IsCompleted;
        //        return Request.CreateResponse(HttpStatusCode.OK, task);

        //    }
        //    catch (Exception)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}
        //public HttpResponseMessage Delete(int id, [FromBody]Task.Domain.Entity.Task task)
        //{
        //    Task.Domain.Entity.Task toDelete = _repository.Tasks.Where(t => t.Id == id).FirstOrDefault();
        //    if(toDelete == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //    try
        //    {
        //        _repository.Tasks.ToList().Remove(toDelete);
        //        return Request.CreateResponse(HttpStatusCode.OK); 
        //    }
        //    catch(Exception)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //    }
        //}

    }
}
