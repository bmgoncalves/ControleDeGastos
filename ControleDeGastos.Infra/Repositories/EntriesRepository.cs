using ControleDeGastos.ApplicationCore.Entities;
using ControleDeGastos.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ControleDeGastos.Infra.Repositories
{
    public class EntriesRepository : IEntriesRepository
    {
        private readonly AppDbContext _context;
        public EntriesRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Entries l)
        {
            _context.Entries.Add(l); 
            _context.SaveChanges();
        }
        public void Update(Entries l)
        {
            _context.Entries.Update(l);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = GetById(id);
            if (e != null)
            {
                _context.Entries.Remove(e);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Entries.Where(e =>e.Id == id).Any();
        }

        public Entries GetById(int id)
        {
            return _context.Entries
                           .Where(e => e.Id == id)
                           .Include(c => c.Categories)
                           .FirstOrDefault();
        }

        public IEnumerable<Entries> GetAll()
        {
            return _context.Entries
                           .Include(c => c.Categories)
                           .ToList();
        }

        public IEnumerable<Entries> GetByDate(DateTime d)
        {
            return _context.Entries
                           .Where(e => e.DateTransaction == d)
                           .Include(c => c.Categories)
                           .ToList();
        }

    }
}
