using System.Collections.Generic;
using System.Linq;

namespace Task.Domain.Abstract
{
    public interface ITaskRepository : IBaseRepository<Task.Domain.Entity.Task>
    {
        //  IQueryable<Task.Domain.Entity.Task> Tasks { get; }
        bool IsTaskExist(string name);

    }
}
