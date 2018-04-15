using System.Linq;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLInk.Data.Repository
{
    public interface IRepository<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
