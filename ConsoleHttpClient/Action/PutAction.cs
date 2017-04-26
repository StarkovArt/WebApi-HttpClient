using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;


namespace ConsoleHttpClient.Action
{
    class PutAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Введите id задачи для изменения");

            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите новое имя задачи");

            Task t = new Task();
            t.Name = Console.ReadLine();

            Console.WriteLine("Введите значение IsComplited [true | false]:");
            t.IsCompleted = Convert.ToBoolean(Console.ReadLine());

            HttpResponseMessage response = client.PutAsync<Task>(Program.URI + "/" + id, t, new JsonMediaTypeFormatter()).Result;

            if (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Эллемент изменен");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("404. Not found");
            }

        }
    }
}
