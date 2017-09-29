using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogHost.Domain.Entities;

namespace BlogHost.Web.Models
{
    public class PostListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}