using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ConsoleHttpClient.Action
{
    class DeleteAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Введите id задачи для удаления");

            int id = Convert.ToInt32(Console.ReadLine());

            HttpResponseMessage responce = client.DeleteAsync(Program.URI + "/" + id).Result;

            if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                Console.WriteLine("Задача удалена");
            }
            else if (responce.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Ошибка на сервере");
            }
        }



    }
}
