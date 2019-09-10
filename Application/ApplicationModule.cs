using Autofac;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Module = Autofac.Module;


namespace Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var opt = new DbContextOptionsBuilder<Context>();
                opt.UseSqlServer(Context.connectionString);
                return new Context(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();

        }
    }
}
