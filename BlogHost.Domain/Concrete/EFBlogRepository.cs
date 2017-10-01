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

        public void AddBlog(string userName, Blog blog)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == userName);
            if(user == null)
                return;
            blog.UserId = user.ID;
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }
    }
}
