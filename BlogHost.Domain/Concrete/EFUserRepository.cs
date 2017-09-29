using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private readonly BlogContext _context = new BlogContext();

        public IQueryable<User> GetAllUsers => _context.Users;

        public void SaveUser(User user)
        {
            if (user.ID == 0)
                _context.Users.Add(user);
            else
            {
                User dbEntity = _context.Users.Find(user.ID);
                if (dbEntity != null)
                {
                    dbEntity.Email = user.Email;
                    dbEntity.Password = user.Password;
                    dbEntity.RoleId = user.RoleId;
                    dbEntity.Username = user.Username;
                }
            }
            _context.SaveChanges();
        }

        public User DeleteUser(int id)
        {
            User dbEntry = _context.Users.Find(id);
            if (dbEntry != null)
            {
                _context.Users.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public User GetByEmail(string email)
        {
            var user = (from u in _context.Users
                where u.Email == email
                select u).FirstOrDefault();
            return user;
        }
    }
}
