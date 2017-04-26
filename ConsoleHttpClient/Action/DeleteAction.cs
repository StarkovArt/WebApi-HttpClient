using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;

namespace ConsoleHttpClient.Action
{
    class DeleteAction :Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            Console.WriteLine("Введите Id задачи");

            int id = Convert.ToInt32(Console.ReadLine());

            HttpResponseMessage response = client.DeleteAsync(Program.URI + "/" + id).Result;

            if(response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Элемент удален");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("404. Not Found");
            }
        }
       

    }
}
