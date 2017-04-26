using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace ConsoleHttpClient.Action
{
     class GetAction : Action
    {
        public override void Invoke()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responce = client.GetAsync(Program.URI).Result;

            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string responseText = responce.Content.ReadAsStringAsync().Result;
                IEnumerable<ConsoleHttpClient.Entity.Task> tasks = jsSerializer.Deserialize<IEnumerable<ConsoleHttpClient.Entity.Task>>(responseText);
                foreach (ConsoleHttpClient.Entity.Task item in tasks)
                {
                    Console.WriteLine("{0,3} - {1,20} {2,10}", item.ID, item.Name, item.IsCompleted);
                }
            }
            else if (responce.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Program.PrintError("404. Not found");
            }
            
        }
    }
}
