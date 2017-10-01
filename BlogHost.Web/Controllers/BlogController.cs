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
    [Authorize]
    public class BlogController : Controller
    {
        private IBlogRepository Repository { get; }

        public int PageSize => 4;

        public BlogController(IBlogRepository rep)
        {
            Repository = rep;
        }
        // GET: Blog
        public ActionResult List(int page = 1)
        {
            BlogListViewModel model = new BlogListViewModel
            {
                Posts = Repository.GetAllBlogs
                    .OrderByDescending(p => p.Date)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = Repository.GetAllBlogs.Count()
                }
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Date = DateTime.Now;
                string userName = User.Identity.Name;
                Repository.AddBlog(userName, blog);
            }
            return RedirectToAction("List");
        }
    }
}