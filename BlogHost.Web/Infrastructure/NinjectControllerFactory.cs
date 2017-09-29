using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlogHost.Domain.Abstract;
using BlogHost.Domain.Concrete;


namespace BlogHost.Web.Infrastructure
{
    // реализация пользовательской фабрики контроллеров, 
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера 
            // используя его тип
            return controllerType == null
                ? null
                : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IBlogRepository>().To<EFBlogRepository>();
            _ninjectKernel.Bind<IPostRepository>().To<EFPostRepository>();
            _ninjectKernel.Bind<IUserRepository>().To<EFUserRepository>();
        }
    }
}