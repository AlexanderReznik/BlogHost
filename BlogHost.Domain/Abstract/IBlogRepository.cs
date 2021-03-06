﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Abstract
{
    public interface IBlogRepository
    {
        IQueryable<Blog> GetAllBlogs { get; }

        void AddBlog(string userName, Blog blog);
    }
}
