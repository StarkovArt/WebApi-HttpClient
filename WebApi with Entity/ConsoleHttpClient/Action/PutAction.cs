using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ConsoleHttpClient.Action
{
    class PutAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Введите id для задачи изменения");

            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новое имя задачи");

            ConsoleHttpClient.Entity.Task t = new ConsoleHttpClient.Entity.Task();
            t.Name = Console.ReadLine();

            Console.WriteLine("Введите значение IsComplited [true | false]:");
            t.IsCompleted = Convert.ToBoolean(Console.ReadLine());

            HttpResponseMessage response = client.PutAsync<ConsoleHttpClient.Entity.Task>(Program.URI + "/" + id, t, new JsonMediaTypeFormatter()).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Created || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Задача изменена");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Console.WriteLine("404. Внутренняя ошибка сервера");
            }
        }
    }
}
