namespace DecorTransientDelegateBug.BLL
{
    public class ServiceDependencyBLL : IServiceDependencyBLL
    {
        public string GetValueA()
        {
            return "dependency";
        }
    }
}
