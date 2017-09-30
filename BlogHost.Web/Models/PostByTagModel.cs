using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogHost.Web.Models
{
    public class PostByTagModel : PostListViewModel
    {
        public string TagName { get; set; }
    }
}