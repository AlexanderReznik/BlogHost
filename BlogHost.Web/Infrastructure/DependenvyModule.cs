using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Concrete;
using Ninject.Modules;

namespace BlogHost.Web.Infrastructure
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<EFUserRepository>();
            Bind<IRoleRepository>().To<EFRoleRepository>();
        }
    }
}