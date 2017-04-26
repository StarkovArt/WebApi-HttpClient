using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ConsoleHttpClient.Action
{
    class PostAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Введите имя задачи");

            ConsoleHttpClient.Entity.Task t = new Entity.Task();
            t.Name = Console.ReadLine();
            t.IsCompleted = false;

            HttpResponseMessage responce = client.PostAsync<ConsoleHttpClient.Entity.Task>(Program.URI, t, new JsonMediaTypeFormatter()).Result;
            if(responce.StatusCode == System.Net.HttpStatusCode.Created || responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Элемент создан");
            }
            if(responce.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Console.WriteLine("404. Ошибка сервера");
            }
        }
    }
}
