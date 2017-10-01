using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogHost.Domain.Entities;

namespace BlogHost.Web.Models
{
    public class PostInBlogModel:PostListViewModel
    {
        public string BlogName { get; set; }
        public int BlogId { get; set; }
        public string UserEmail { get; set; }
    }
}