using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace CDNVNONE.IoC
{
    public class CDNVNUnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        public CDNVNUnityDependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }
        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            if (!container.IsRegistered(serviceType) && (serviceType.IsAbstract || serviceType.IsInterface))
            {
                return null;
            }
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new CDNVNUnityDependencyResolver(child);
        }
    }
}
