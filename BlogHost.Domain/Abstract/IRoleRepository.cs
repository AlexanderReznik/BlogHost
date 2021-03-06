﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Abstract
{
    public interface IRoleRepository
    {
        IQueryable<Role> GetAllRoles();
        Role GetById(int? roleId);
    }
}
