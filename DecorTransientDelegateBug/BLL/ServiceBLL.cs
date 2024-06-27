using Decor;
using DecorTransientDelegateBug.Cache;

namespace DecorTransientDelegateBug.BLL
{
    public class ServiceBLL : IServiceBLL
    {
        private readonly IServiceDependencyBLL serviceDependencyBLL;

        public ServiceBLL(IServiceDependencyBLL serviceDependencyBLL)
        {
            this.serviceDependencyBLL = serviceDependencyBLL;
        }

        [Decorate(typeof(CacheDecorator))]
        public string GetValueB()
        {
            return "dependency" + this.serviceDependencyBLL.GetValueA();
        }
    }
}
