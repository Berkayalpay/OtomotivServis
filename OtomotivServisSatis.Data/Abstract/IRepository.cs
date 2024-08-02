using System.Linq.Expressions;

namespace OtomotivServisSatis.Data.Abstract
{
    //TEMEL CRUD İşlemlerimiz yapmamızı sağlayacak Repo tarafımız.
    public interface IRepository<T> where T : class //şart koştuk bu T bir class olmalı
    {
        //SENKRON METOTLAR
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T,bool>> expression); //lambda expression kullanarak veri listelemek için
        T Get(Expression<Func<T,bool>> expression);
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();

        //ASENKRON METOTLAR (çalışması ıcın taskin içine alıyoruz)
        Task<T> FindAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task <List<T>> GetAllAsync();
        Task <List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<int> SaveAsync();
    }
}
