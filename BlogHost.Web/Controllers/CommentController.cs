using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Web.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository Repository { get; }

        public CommentController(ICommentRepository rep)
        {
            Repository = rep;
        }
        // GET: Comment
        public ActionResult Add(int postid)
        {
            ViewBag.PostId = postid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Comment c, int postid)
        {
            if (ModelState.IsValid)
            {
                c.PostId = postid;
                c.Date = DateTime.Now;
                Repository.AddComment(c, User.Identity.Name);
            }
            return RedirectToAction("Get", "Post", new {id = postid});
        }
    }
}