using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Irepo
{
    public interface Irepo<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Create(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
