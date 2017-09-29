using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Concrete
{
    public class EFBlogRepository : IBlogRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public IQueryable<Blog> GetAllBlogs => _context.Blogs;
    }
}
