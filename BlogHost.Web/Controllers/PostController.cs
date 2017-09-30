using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;
using BlogHost.Web.Models;

namespace BlogHost.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository Repository { get; }
        public int PageSize => 4;

        public PostController(IPostRepository rep)
        {
            Repository = rep;
        }

        public ActionResult List(int page = 1)
        {
            PostListViewModel model = new PostListViewModel
            {
                Posts = Repository.GetAllPosts
                    .OrderByDescending(p => p.Date)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = Repository.GetAllPosts.Count()
                }
            };

            ViewBag.Title = "Latest posts";

            return View(model);
        }

        public ActionResult Get(int id = 1)
        {
            Post post = Repository.GetById(id);
            if (post == null) return HttpNotFound("No such post");

            return View("PostFull", post);
        }

        public ActionResult InBlog(int blogId, string blogName, int page = 1)
        {
            var posts = Repository.GetAllPosts
                .Where(p => p.BlogId == blogId)
                .OrderByDescending(p => p.Date);

            PostInBlogModel model = new PostInBlogModel
            {
                Posts = posts
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = posts.Count()
                },
                BlogId = blogId,
                BlogName = blogName
            };

            return View(model);
        }
    }
}