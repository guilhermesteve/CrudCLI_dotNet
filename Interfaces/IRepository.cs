using System.Collections.Generic;

namespace DIO.PSeries.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T GetById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entidade);
        int NextId();

    }
}