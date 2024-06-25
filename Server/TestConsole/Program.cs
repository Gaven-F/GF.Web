using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

var logo = """
    -------------------------------------------
     ██████╗ ███████╗██╗    ██╗███████╗██████╗ 
    ██╔════╝ ██╔════╝██║    ██║██╔════╝██╔══██╗
    ██║  ███╗█████╗  ██║ █╗ ██║█████╗  ██████╔╝
    ██║   ██║██╔══╝  ██║███╗██║██╔══╝  ██╔══██╗
    ╚██████╔╝██║██╗  ╚███╔███╔╝███████╗██████╔╝
     ╚═════╝ ╚═╝╚═╝   ╚══╝╚══╝ ╚══════╝╚═════╝ 
    -------------------------------------------
    """;

logo.ToList().ForEach(c =>
{
    Console.Write(c);
    Task.Delay(1).Wait();
});
Console.WriteLine();

Console.WriteLine("这只是一个测试使用的控制台，代码逻辑测试");

var service = new ServiceCollection();

service.AddMemoryCache();

var serviceCollection = service.BuildServiceProvider();

var cache = serviceCollection.GetService<IMemoryCache>();

var data1 = cache!.GetOrCreate("KEY1", (cacheEntity) =>
{
    Console.WriteLine("Create Key 1");
    cacheEntity.SlidingExpiration = TimeSpan.FromSeconds(30);
    return "Data01";
});

var data2 = cache!.GetOrCreate("KEY1", (cacheEntity) =>
{
    Console.WriteLine("Create Key 1");
    cacheEntity.SlidingExpiration = TimeSpan.FromSeconds(30);
    return "Data01";
});

Console.WriteLine(data1);
Console.WriteLine(data2);

Console.WriteLine(data2!.Equals(data1));



#region Redis Service
//service.AddStackExchangeRedisCache(
//    (options) =>
//    {
//        options.Configuration = "s4.serv00.com:63857,password=GY00..yl";
//        options.InstanceName = "DEMO_";
//    }
//);

//var serviceCollection = service.BuildServiceProvider();

////var redis = serviceCollection.GetService<IDistributedCache>();
//var redis = serviceCollection.GetService<IDistributedCache>();
//var data1 = redis?.GetString("Date1");
//var data2 = redis?.GetString("data2");


//redis?.SetString(
//    "data1",
//    "Data",
//    new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1) }
//);
//redis?.SetString(
//    "data2",
//    "Data2",
//    new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromSeconds(30) }
//);

//Console.WriteLine(data2);
#endregion
