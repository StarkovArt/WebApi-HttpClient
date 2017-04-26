using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http;


namespace ConsoleHttpClient.Action
{
    class PostAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Введите имя задачи:");

            Task t = new Task();
            t.Name = Console.ReadLine();
            t.IsCompleted = false;

            HttpResponseMessage responce = client.PostAsync<Task>(Program.URI, t, new JsonMediaTypeFormatter()).Result;

            if(responce.StatusCode == HttpStatusCode.Created || responce.StatusCode == HttpStatusCode. OK)
            {
                Console.WriteLine("Элемент создан");
            }
            else if(responce.StatusCode == HttpStatusCode.NotFound)
            {
                Program.PrintError("404. Not Found");
            }
        }
    }
}
