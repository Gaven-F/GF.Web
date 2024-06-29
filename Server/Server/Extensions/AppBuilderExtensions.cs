using Builder = Microsoft.AspNetCore.Builder.WebApplicationBuilder;

namespace Server.Extensions;

public static class AppBuilderExtensions
{
    /// <summary>
    /// 启用控制器
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static Builder EnableController(this Builder builder)
    {
        builder.Services.AddControllers();
        return builder;
    }

    /// <summary>
    /// 注入Swagger的文档服务
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static Builder EnableSwaggerDoc(this Builder builder)
    {
        //TODO: 从配置文件读取配置
        //var conf = builder.Configuration;
        builder.Services.AddOpenApiDocument(c => { });
        return builder;
    }
}
