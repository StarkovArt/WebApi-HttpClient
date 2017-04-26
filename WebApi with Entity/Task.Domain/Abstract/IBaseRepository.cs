using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Abstract
{
    public interface IBaseRepository <T>
    {
        T Get(int id);
        T Create(T entity);
        List<T> GetAll();
        void Delete(int id);
        T Update(T entity);

    }
}
