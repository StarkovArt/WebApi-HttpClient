using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace ConsoleHttpClient.Action
{
    class GetAction : Action // Наследуемся от Action
    {
        public override void Invoke() //Переопределение метода Invoke
        {
            HttpClient client = new HttpClient(); // Создание экземпляра класса HttpClient
            HttpResponseMessage responce = client.GetAsync(Program.URI).Result; // Создания экземпляра , Web API преобразует возвращаемое значение в текст ответа HTTP
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string resposeText = responce.Content.ReadAsStringAsync().Result; ;
                IEnumerable<Task> tasks = jsSerializer.Deserialize<IEnumerable<Task>>(resposeText);
                foreach(Task item in tasks)
                {
                    Console.WriteLine("{0,3} - {1,20} {2,10}", item.ID, item.Name, item.IsCompleted);
                }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            }
            else if (responce.StatusCode == HttpStatusCode.NotFound)
            {
                Program.PrintError("404.Not Found");
            }
        }


    }
}
