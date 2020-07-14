using System.Collections.Generic;

namespace StudentService.DAL.Interfaces
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        void Update(T item);

        T Delete(int id);
    }
}
