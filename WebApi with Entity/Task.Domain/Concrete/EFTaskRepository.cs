using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Abstract;

namespace Task.Domain.Concrete
{
    public class EFTaskRepository : ITaskRepository
    {
        EFDbContext context = new EFDbContext();

        public EFTaskRepository(EFDbContext cont)
        {
            this.context = cont;
        }
        public Task.Domain.Entity.Task Create(Task.Domain.Entity.Task entity)
        {
            context.Tasks.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public Task.Domain.Entity.Task Get(int id)
        {
            return context.Tasks.Single(t => t.Id == id);
        }
        public List<Task.Domain.Entity.Task> GetAll()
        {
            return context.Tasks.ToList();
        }
        public bool IsTaskExist(string name)
        {
            return context.Tasks.Any(t => t.Name == name);
        }
        public void Delete(int id)
        {
            var task = context.Tasks.Attach(new Entity.Task { Id = id });
            var entry = context.Entry(task);
            entry.State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }
        public Task.Domain.Entity.Task Update(Task.Domain.Entity.Task entity)
        {
            var task = context.Tasks.Attach(entity);
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return task;
        }
    }
}
