using ControleDeGastos.ApplicationCore.Entities;
using ControleDeGastos.Infra.Repositories.Interface;

namespace ControleDeGastos.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context; 
        }

        public void Add(Category c)
        {
            _context.Categories.Add(c);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = GetById(id);
            if (c != null)
            {
                _context.Categories.Remove(c);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Categories.Where(c => c.Id == id).Any();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public Category GetByName(string name)
        {
            return _context.Categories.Where(c => c.Description == name).FirstOrDefault();
        }

        public void Update(Category c)
        {
            if (Exists(c.Id))
            {
                _context.Categories.Update(c);
                _context.SaveChanges();
            }
        }
    }
}
