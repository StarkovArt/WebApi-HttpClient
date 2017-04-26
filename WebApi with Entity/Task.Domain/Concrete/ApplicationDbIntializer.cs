using System.Data.Entity;

namespace Task.Domain.Concrete
{
    public class ApplicationDbIntializer : CreateDatabaseIfNotExists<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var task = new Task.Domain.Entity.Task
            {
                Id = 1,
                Name = "Сделать уроки",
                IsCompleted = true
            };

            var task2 = new Task.Domain.Entity.Task
            {
                Id = 2,
                Name = "Помыть посуду",
                IsCompleted = true
            };
            var task3 = new Task.Domain.Entity.Task
            {
                Id = 3,
                Name = "Выучить C#",
                IsCompleted = true
            };
            context.Tasks.Add(task);
            context.Tasks.Add(task2);
            context.Tasks.Add(task3);

            context.SaveChanges();
        }
    }
}
