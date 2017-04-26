using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleClient.Models
{
    public class Task // Создаем класс Entity
    {
        public int Id { get; set; } // Id задачи
        public string Name { get; set; } // Имя названия
        public bool IsCompleted { get; set; } // Выполнено ли задание
    }
}