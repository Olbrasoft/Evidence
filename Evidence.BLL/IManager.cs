using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Evidence.DTO;

namespace Evidence.BLL
{
    public interface IManager<T>
    {
        T Get(int id);
        IEnumerable<T> Get();
        void Save(T entity);
        void Delete(int id);
    }
}
