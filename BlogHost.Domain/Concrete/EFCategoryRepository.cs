using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public IQueryable<Category> GetAllCategories => _context.Categories;

        public Category GetByName(string name)
        {
            Category category = _context.Categories.FirstOrDefault(t => t.Name == name);
            if (category == null)
            {
                _context.Categories.Add(new Category { Name = name, Description = $"About {name}"});
                _context.SaveChanges();
                return _context.Categories.FirstOrDefault(t => t.Name == name);
            }
            return category;
        }
    }
}
