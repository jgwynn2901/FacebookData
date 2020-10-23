using System.Collections.Generic;
using FacebookData.Models;

namespace FacebookData.Repository
{
  public interface IRepository<T> where T : BaseModel
  {
    int Add(T item);
    bool Remove(int id);
    bool Update(T item);
    T FindById(int id);
    IEnumerable<T> FindAll();
  }
}
