using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAllComments { get; }
        void AddComment(Comment c, string email);
        Comment GetById(int id);
        void SaveComment(Comment comment);
        Comment DeleteComment(int id);
    }
}
