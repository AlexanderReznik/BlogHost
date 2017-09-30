using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogHost.Domain.Entities;

namespace BlogHost.Web.Models
{
    public class BlogListViewModel
    {
        public IEnumerable<Blog> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}