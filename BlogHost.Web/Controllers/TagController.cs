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
    public class TagController : Controller
    {
        private ITagRepository Repository { get; }
        public int PageSize => 4;

        public TagController(ITagRepository rep)
        {
            Repository = rep;
        }

        public ActionResult Search(string tagName, int page = 1)
        {
            Tag tag = Repository.GetByName(tagName);

            if (tag == null)
            {
                return View(new PostByTagModel
                {
                    Posts = null,
                    PagingInfo = null,
                    TagName = tagName
                });
            }

            PostByTagModel model = new PostByTagModel
            {
                Posts = tag.Posts,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = tag.Posts.Count()
                },
                TagName = tagName
            };

            return View(model);
        }
    }
}