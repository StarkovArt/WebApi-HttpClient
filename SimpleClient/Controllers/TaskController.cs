using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleClient.Models;

namespace SimpleClient.Controllers
{
    public class TaskController : ApiController
    {
        public IEnumerable<Task> Get() //Инициализация метода Get
        {
            return TaskDataSource.All; // Возвращаем все данные
        }

        public HttpResponseMessage Post([FromBody]Task task) // Инициализация метода Post
        {
            try //Проверка ошибки
            {
                int id = TaskDataSource.All.Max(i => i.Id); //Создание id, поиск максимального
                task.Id = id + 1; // Присваиваем + 1 к id
                TaskDataSource.All.Add(task); // Добавляем новую задачу
                return Request.CreateResponse(HttpStatusCode.Created, task); // Возвращаем созданую task
            }
            catch (Exception) // Отлавливаем ошибку
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError); //Возвращаем ошибку
            }
        }
        public HttpResponseMessage Put(int id, [FromBody]Task task) // Создаем HTTP глагол 
        {
            Task oldTask = TaskDataSource.All.Where(o => o.Id == id).FirstOrDefault(); // Находим task который надо поменять
            if(oldTask == null) // Проверяем на null 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound); // Если null, возвращаем код ошибки Not found
            }
            try // оператор try
            {
                oldTask.Name = task.Name; // Присваиваем новое имя
                oldTask.IsCompleted = task.IsCompleted; // Присваиваем bool сделана ли задача

                return Request.CreateResponse(HttpStatusCode.OK, task); //Возвращаем ответ
            }
            catch (Exception) // оператор catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError); // Возвращае HttpStatusCode с внутреней ошибкой
            }
        }
        public HttpResponseMessage Delete(int id, [FromBody]Task task) // Создание метода c HTTP глагола Delete
        {
            Task toDelete = TaskDataSource.All.Where(t => t.Id == id).FirstOrDefault(); // Находим по id
            if(toDelete == null) // Проверяем на null
            {
                return Request.CreateResponse(HttpStatusCode.NotFound); // Если toDelete == null вернуть ошибку not found
            }
            try // оператор try
            {
                TaskDataSource.All.Remove(toDelete); // Удаление 
                return Request.CreateResponse(HttpStatusCode.OK); // Отправить код HttpStatusCode OK
            }
            catch(Exception) // оператор catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError); // Возвращаем если словили ошибку внутрению ошибку сервера
            }
        }
    }
}
