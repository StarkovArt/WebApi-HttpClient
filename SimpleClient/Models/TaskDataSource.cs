using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleClient.Models
{
    public class TaskDataSource // Создаем класс для иммитации данных в БД
    {
        private static List<Task> _task = null; // Параметризированный лист

        public static List<Task> All // Лист дающий доступ ко всем экземпляра List<Task> _task
        {
            get // getter
            {
                if (_task == null) //Проверка на null
                {
                    _task = new List<Task>(); // НЕПОНЯТНО для чего тут потом проверить НАДО
                    _task.Add(new Task() { Id = 1, Name = "Выполнения задачи по topAvia", IsCompleted = false }); // Добавляем данные в List<Task> _tasks 
                    _task.Add(new Task() { Id = 1, Name = "Выполнения задачи по topBelarus", IsCompleted = false }); // Добавляем данные в List<Task> _tasks 
                    _task.Add(new Task() { Id = 1, Name = "Выполнения задачи по topTour", IsCompleted = false }); // Добавляем данные в List<Task> _tasks 
                }
                return _task; //Возвращаем в геттер List<Task> _task
            }
        }
    }
}