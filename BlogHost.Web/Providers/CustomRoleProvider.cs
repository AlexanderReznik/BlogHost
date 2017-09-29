using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Entities;

namespace BlogHost.Web.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public IUserRepository UserRepository
            => (IUserRepository)DependencyResolver.Current.GetService(typeof(IUserRepository));

        public IRoleRepository RoleRepository
            => (IRoleRepository)DependencyResolver.Current.GetService(typeof(IRoleRepository));

        public override bool IsUserInRole(string email, string roleName)
        {

            User user = UserRepository.GetAllUsers.FirstOrDefault(u => u.Email == email);

            if (user == null) return false;

            Role userRole = RoleRepository.GetById(user.RoleId);

            if (userRole != null && userRole.Name == roleName)
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string email)
        {
            string[] roles = new string[] { };
            var user = UserRepository.GetByEmail(email);
            if (user == null) return roles;

            var role = RoleRepository.GetById(user.RoleId);
            return new string[] {role.Name};
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}