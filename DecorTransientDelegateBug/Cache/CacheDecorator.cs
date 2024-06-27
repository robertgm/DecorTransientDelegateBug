using Decor;

namespace DecorTransientDelegateBug.Cache
{
    public class CacheDecorator : IDecorator
    {
        public async Task OnInvoke(Call call)
        {
            await call.Next();
        }
    }
}
