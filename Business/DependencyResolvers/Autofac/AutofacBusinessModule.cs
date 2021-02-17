using Autofac;
using Business.Abstract;
using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)  
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();   // WebAPI'da statup içerisinde yapmaktansa burada aynı şekilde birisi senden IproductService isterse ProductManager referansı ver
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
