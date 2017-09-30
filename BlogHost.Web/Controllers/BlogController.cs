﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogHost.Domain.Abstract;
using BlogHost.Web.Models;

namespace BlogHost.Web.Controllers
{
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
    }
}