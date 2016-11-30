using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Klasifikacija_KNN.Domain.Abstract;
using Klasifikacija_KNN.Domain.Concrete;
using Moq;
using Ninject;

namespace Klasifikacija_KNN.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IPlanRepository>().To<EfPlansRepository>();
            _kernel.Bind<IDistanceCalculator>().To<DistanceCalculator>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}