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

        public Tag GetByName(string name)
        {
            Tag tag = _context.Tags.FirstOrDefault(t => t.Name == name);
            if (tag == null)
            {
                _context.Tags.Add(new Tag {Name = name});
                _context.SaveChanges();
                return _context.Tags.FirstOrDefault(t => t.Name == name);
            }
            return tag;
        }
    }
}
