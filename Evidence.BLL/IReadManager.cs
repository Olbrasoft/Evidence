using System;
using System.Collections.Generic;
using System.Linq;

namespace Evidence.BLL
{
    public interface IReadManager<T>
    {
        T Get(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(int page, int size, Func<IQueryable<T>, IQueryable<T>> filterAndSort, out int pageCount);
    }
}
