using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

var GF_WEB_LOGO = """
    -------------------------------------------
     ██████╗ ███████╗██╗    ██╗███████╗██████╗ 
    ██╔════╝ ██╔════╝██║    ██║██╔════╝██╔══██╗
    ██║  ███╗█████╗  ██║ █╗ ██║█████╗  ██████╔╝
    ██║   ██║██╔══╝  ██║███╗██║██╔══╝  ██╔══██╗
    ╚██████╔╝██║██╗  ╚███╔███╔╝███████╗██████╔╝
     ╚═════╝ ╚═╝╚═╝   ╚══╝╚══╝ ╚══════╝╚═════╝ 
    -------------------------------------------
    """;

foreach (var @char in GF_WEB_LOGO)
{
    Console.Write(@char);
}

Console.WriteLine();
Console.WriteLine("这只是一个测试使用的控制台，代码逻辑测试");

var service = new ServiceCollection();
service.AddStackExchangeRedisCache(
    (options) =>
    {
        options.Configuration = "s4.serv00.com:63857,password=GY00..yl";
        options.InstanceName = "DEMO_";
    }   
);

var serviceCollection = service.BuildServiceProvider();

//var redis = serviceCollection.GetService<IDistributedCache>();
var redis = serviceCollection.GetService<IDistributedCache>();
var data1 = redis?.GetString("Date1");
var data2 = redis?.GetString("data2");


redis?.SetString(
    "data1",
    "Data",
    new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1) }
);
redis?.SetString(
    "data2",
    "Data2",
    new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromSeconds(30) }
);

Console.WriteLine(data2);
