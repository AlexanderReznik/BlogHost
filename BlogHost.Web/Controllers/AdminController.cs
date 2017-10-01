using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IPostRepository PostRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

        public AdminController(IPostRepository ipr, ICommentRepository icr, IUserRepository iur, ITagRepository itr, ICategoryRepository icatr)
        {
            PostRepository = ipr;
            CommentRepository = icr;
            TagRepository = itr;
            UserRepository = iur;
            CategoryRepository = icatr;
        }
        public ActionResult Index()
        {
            return View();
        }

        #region Posts

        public ActionResult Posts()
        {
            return View(PostRepository.GetAllPosts);
        }

        public ActionResult EditPost(int id)
        {
            Post post = PostRepository.GetById(id);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Post post)
        {
            post.CategoryId = CategoryRepository.GetByName(post.Category.Name).ID;
            PostRepository.SavePost(post);
            return RedirectToAction("Posts");
        }

        public ActionResult DeletePost(int id)
        {
            Post post = PostRepository.DeletePost(id);
            return RedirectToAction("Posts");
        }

        #endregion

        #region Comments

        public ActionResult Comments()
        {
            return View(CommentRepository.GetAllComments);
        }

        public ActionResult EditComment(int id)
        {
            Comment comment= CommentRepository.GetById(id);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment(Comment comment)
        {
            CommentRepository.SaveComment(comment);
            return RedirectToAction("Comments");
        }

        public ActionResult DeleteComment(int id)
        {
            Comment comment = CommentRepository.DeleteComment(id);
            return RedirectToAction("Comments");
        }

        #endregion
    }
}