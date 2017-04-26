using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Entity
{
    public class Task //Создаем класс Entity
    {
        public int Id { get; set; } // Id задачи
        public string Name { get; set; } // Имя задачи
        public bool IsCompleted { get; set; } // Выолненно ли задание
    }
}
