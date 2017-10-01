using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAllPosts { get; }
        Post GetById(int id);
        void SavePost(Post post);
        Post DeletePost(int id);
        void AddPost(Post post, string[] tags, string category);
    }
}
