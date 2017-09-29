using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Concrete
{
    public class EFRoleRepository : IRoleRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public IQueryable<Role> GetAllRoles() => _context.Roles;

        public Role GetById(int? roleId) => _context.Roles.Find(roleId);
    }
}
