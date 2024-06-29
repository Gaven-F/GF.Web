using App = Microsoft.AspNetCore.Builder.WebApplication;

namespace Server.Extensions;

public static class AppExtensions
{
    /// <summary>
    /// 使用Swagger中间件，需要放在Routing中间件后
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    /// <remarks>U means use</remarks>
    public static App USwagger(this App app)
    {
        //TODO: 从配置文件读取配置
        //var conf = app.Configuration;
        app.UseOpenApi(c => { }).UseSwaggerUi(c => { });
        return app;
    }
}
