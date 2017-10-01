using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Concrete
{
    public class EFCommentRepository : ICommentRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public IQueryable<Comment> GetAllComments => _context.Comments;

        public void AddComment(Comment c, string email)
        {
            c.UserId = GetUserId(email);
            _context.Comments.Add(c);
            _context.SaveChanges();
        }

        private int GetUserId(string email) => _context.Users.FirstOrDefault(u => u.Email == email).ID;

    }
}
