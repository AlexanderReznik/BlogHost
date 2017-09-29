using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Concrete
{
    public class EFPostRepository : IPostRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public IQueryable<Post> GetAllPosts => _context.Posts;
    }
}
