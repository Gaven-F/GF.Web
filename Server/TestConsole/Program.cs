using Microsoft.Extensions.Configuration;

var conf = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.local.json")
    .Build();

var data = new DemoOptions();

conf.GetSection(nameof(DemoOptions)).Bind(data);

Console.WriteLine(data.SubOption?.SubOption?.SubOption?.SubOption?.DemoData);

public class DemoOptions
{
    [ConfigurationKeyName("Demo")]
    public string DemoData { get; set; } = string.Empty;

    public DemoOptions? SubOption { get; set; }
}
