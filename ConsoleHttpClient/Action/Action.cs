using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHttpClient.Action
{
    abstract class Action //Создание абстрактного класса
    {
        public abstract void Invoke(); // Определение  обстарктоного метода для переопределения
    }
}
