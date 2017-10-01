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

        public Comment GetById(int id) => _context.Comments.Find(id);

        public void SaveComment(Comment comment)
        {
            if (comment.ID == 0)
                _context.Comments.Add(comment);
            else
            {
                Comment dbComment = _context.Comments.Find(comment.ID);
                if (dbComment != null)
                {
                    dbComment.Text = comment.Text;
                    dbComment.Date = comment.Date;
                }
            }
            _context.SaveChanges();
        }

        public Comment DeleteComment(int id)
        {
            Comment comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
            return comment;
        }

        private int GetUserId(string email) => _context.Users.FirstOrDefault(u => u.Email == email).ID;

    }
}
