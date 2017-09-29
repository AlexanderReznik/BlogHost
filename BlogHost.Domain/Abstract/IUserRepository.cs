using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers { get; }
        void SaveUser(User user);
        User DeleteUser(int id);
        User GetByEmail(string email);
    }
}
