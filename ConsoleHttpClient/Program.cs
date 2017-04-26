using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleHttpClient.Action;

namespace ConsoleHttpClient
{
    class Program
    {
        public const string URI = "http://localhost:58318/api/task";

        static void Main(string[] args)
        {
            start:
            Console.WriteLine("Введите тип запроса - GET, POST, PUT, DELETE");
            string command = Console.ReadLine().ToUpper();
            switch (command)
            {
                case "GET":
                    new GetAction().Invoke();
                    break;
                case "POST":
                    new PostAction().Invoke();
                    break;
                case "DELETE":
                    new DeleteAction().Invoke();
                    break;
                case "PUT":
                    new PutAction().Invoke();
                    break;
                case "EXIT":
                    return;
            }
            goto start;
        }
        public static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
