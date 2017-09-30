using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Concrete
{
    public class EFTagRepository:ITagRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public IQueryable<Tag> GetAllTags => _context.Tags;
        public Tag GetByName(string name) => _context.Tags.FirstOrDefault(t => t.Name == name);
    }
}
