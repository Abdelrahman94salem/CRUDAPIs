using System.Security.Principal;

namespace Application
{
    public interface IWriteRepository<in T>
    {
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }

    public interface IReadRepository<out T>
    {
        IEnumerable<T> ReadAll();
        T ReadById(int id);
    }

    public interface ICRUD<T> : IReadRepository<T>, IWriteRepository<T>
      where T : class
    {
    }

}
