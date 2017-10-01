using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories { get; }
        Category GetByName(string name);
    }
}
