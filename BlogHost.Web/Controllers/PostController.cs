using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogHost.Domain.Abstract;
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

            return View(model);
        }
    }
}