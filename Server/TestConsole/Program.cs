#pragma warning disable CA2208

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
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

logo.ToList()
    .ForEach(c =>
    {
        Console.Write(c);
        Task.Delay(0).Wait();
    });
Console.WriteLine();

Console.WriteLine("这只是一个测试使用的控制台，代码逻辑测试");

var conf = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.local.json")
    .Build();

var service = new ServiceCollection();

service.AddStackExchangeRedisCache(
    (options) =>
    {
        var redisConf = conf.GetSection("Redis") ?? throw new ArgumentNullException("redisConfig");

        options.InstanceName = "DEMO_";
        options.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
        {
            EndPoints = { { redisConf["Host"]!, Convert.ToInt32(redisConf["Port"]) } },
            Password = redisConf["Password"]!,
            DefaultDatabase = Convert.ToInt32(redisConf["DefaultDatabase"]),
        };
    }
);

service.AddMemoryCache();

#region Memory Cacge Service

var serviceCollection = service.BuildServiceProvider();

var cache = serviceCollection.GetService<IMemoryCache>();

var data1 = cache!.GetOrCreate(
    "KEY1",
    (cacheEntity) =>
    {
        Console.WriteLine("Create Key 1");
        cacheEntity.SlidingExpiration = TimeSpan.FromSeconds(30);
        return "Data01";
    }
);

var data2 = cache!.GetOrCreate(
    "KEY1",
    (cacheEntity) =>
    {
        Console.WriteLine("Create Key 1");
        cacheEntity.SlidingExpiration = TimeSpan.FromSeconds(30);
        return "Data01";
    }
);

Console.WriteLine(data1);
Console.WriteLine(data2);

Console.WriteLine(data2!.Equals(data1));
#endregion



#region Redis Service

//var redis = serviceCollection.GetService<IDistributedCache>();
var redis = serviceCollection.GetService<IDistributedCache>();
var r_data1 = redis?.GetString("Date1");
var r_data2 = redis?.GetString("data2");

redis?.SetString(
    "Data1",
    "Data",
    new DistributedCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1) }
);
redis?.SetString(
    "Data2",
    "Data2",
    new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromSeconds(30) }
);

Console.WriteLine(r_data2);
#endregion
