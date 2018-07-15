using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardDB.Conracts.Bases
{
    public interface IRepository<T> where T: class
    {
        bool Add(T entity);
        bool Delete(Guid id);
        bool DeleteAll();
        bool Delete(T entity);
        bool Update(T entity);
        T Get(Guid id);
        IList<T> GetAll();
        T GetLast();
        IList<T> Find(string criteria);
    }
}
