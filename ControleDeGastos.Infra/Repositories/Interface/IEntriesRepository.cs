using ControleDeGastos.ApplicationCore.Entities;

namespace ControleDeGastos.Infra.Repositories.Interface
{
    public interface IEntriesRepository
    {
        void Add(Entries l);
        void Update(Entries l);
        void Delete(int id);
        bool Exists(int id);   
        Entries GetById(int id);
        IEnumerable<Entries> GetAll();
        IEnumerable<Entries> GetByDate(DateTime d); 

    }
}
