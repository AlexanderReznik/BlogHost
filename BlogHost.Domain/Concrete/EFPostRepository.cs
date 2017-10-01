using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public Post GetById(int id) => _context.Posts.Find(id);
        public void SavePost(Post post)
        {
            if (post.ID == 0)
                _context.Posts.Add(post);
            else
            {
                Post dbPost = _context.Posts.Find(post.ID);
                if (dbPost != null)
                {
                    dbPost.CategoryId = post.CategoryId;
                    dbPost.Date = post.Date;
                    dbPost.Title = post.Title;
                    dbPost.UrlSlug = post.UrlSlug;
                    dbPost.Text = post.Text;
                    dbPost.Description = post.Description;
                }
            }
            _context.SaveChanges();
        }

        public Post DeletePost(int id)
        {
            Post post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
            return post;
        }

        public void AddPost(Post post, string[] tags, string category)
        {
            
            foreach (var t in tags)
            {
                post.Tags.Add(GetTag(t));
            }
            post.CategoryId = GetCategoryId(category);
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        private Tag GetTag(string tagname)
        {
            Tag tag = _context.Tags.FirstOrDefault(t => t.Name == tagname);
            if (tag == null)
            {
                _context.Tags.Add(new Tag {Name = tagname});
                _context.SaveChanges();
                return _context.Tags.FirstOrDefault(t => t.Name == tagname);
            }
            return tag;
        }

        private int GetCategoryId(string categoryname)
        {
            Category category = _context.Categories.FirstOrDefault(t => t.Name == categoryname);
            if (category == null)
            {
                _context.Categories.Add(new Category { Name = categoryname , Description = $"About {categoryname}"});
                _context.SaveChanges();
                return _context.Categories.FirstOrDefault(t => t.Name == categoryname).ID;
            }
            return category.ID;
        }
    }
}