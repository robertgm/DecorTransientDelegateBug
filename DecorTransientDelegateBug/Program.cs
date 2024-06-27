using Decor;
using DecorTransientDelegateBug.BLL;
using DecorTransientDelegateBug.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDecor();
builder.Services.AddSingleton<CacheDecorator>();
builder.Services.AddSingleton<IServiceDependencyBLL, ServiceDependencyBLL >().Decorated();
builder.Services.AddSingleton<ServiceBLL>().Decorated();

builder.Services.AddTransient<Func<string, IServiceBLL>>(serviceProvider => account => {
    switch (account)
    {
        case "countryA":
            return serviceProvider.GetService<ServiceBLL>(); // error
        default:
            throw new Exception("Country does not exist.");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
