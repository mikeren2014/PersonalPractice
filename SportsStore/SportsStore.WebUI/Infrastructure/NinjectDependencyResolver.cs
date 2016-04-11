using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstracts;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernalParam)
        {
            kernel = kernalParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            //mockProductRepository.Setup(m => m.Products).Returns( new List<Product> {
            //    new Product { Name="Football", Price=25},
            //    new Product { Name="Surf board", Price=179},
            //    new Product { Name="Running Shoes", Price=97}
            //    });
            //kernel.Bind<IProductRepository>().ToConstant(mockProductRepository.Object);

            kernel.Bind<IProductRepository>().To<EFProductRepository>();

        }
    }
}