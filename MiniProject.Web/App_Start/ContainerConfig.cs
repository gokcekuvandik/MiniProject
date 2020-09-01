using Autofac;
using Autofac.Integration.Mvc;
using MiniProject.Data.IRepository;
using MiniProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>().SingleInstance();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().SingleInstance();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>().SingleInstance();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}