using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogHost.Web.Models
{
    public class PostInBlogModel:PostListViewModel
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
    }
}