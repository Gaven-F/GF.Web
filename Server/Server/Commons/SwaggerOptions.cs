namespace Server.Commons;

public class SwaggerOptions
{
    public SwaggerDocument Doc { get; set; } = new SwaggerDocument();
}
public class SwaggerDocument
{
    public string Description { get; set; } = string.Empty;
    public string[] GroupNames { get; set; } = [];
    public string Name { get; set; } = "GF.Web";
    public SwaggerPostProcess PostProcess { get; set; } = new SwaggerPostProcess();
    public string Title { get; set; } = "GF.Web";
}

public class SwaggerPostProcess
{
    public NSwag.OpenApiContact Contact { get; set; } = new NSwag.OpenApiContact();
    public NSwag.OpenApiLicense License { get; set; } = new NSwag.OpenApiLicense();
    public string Title { get; set; } = "GF.Web";
    public string Version { get; set; } = "0.0.1";
}

