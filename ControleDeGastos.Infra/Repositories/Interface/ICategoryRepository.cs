using ControleDeGastos.ApplicationCore.Entities;

namespace ControleDeGastos.Infra.Repositories.Interface
{
    public interface ICategoryRepository
    {
        void Add(Category c);
        void Update(Category c);    
        void Delete(int id);
        bool Exists(int id);
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        Category GetByName(string name);
        
        
    }
}
