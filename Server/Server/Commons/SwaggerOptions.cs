using Newtonsoft.Json;

namespace Server.Commons;

public class SwaggerOptions : IOption
{
    public SwaggerDocument Doc { get; set; } = new SwaggerDocument();
}

public class SwaggerDocument : IOption
{
    public string Description { get; set; } = string.Empty;

    public string[] GroupNames { get; set; } = [];

    public string Name { get; set; } = "GF.Web";

    public SwaggerPostProcess PostProcess { get; set; } = new SwaggerPostProcess();

    public string Title { get; set; } = "GF.Web";
}

public class SwaggerPostProcess : IOption
{
    private NSwag.OpenApiContact? _contact;

    private NSwag.OpenApiLicense? _license;

    [JsonIgnore]
    public NSwag.OpenApiContact SwaggerContact =>
        _contact ??= new()
        {
            Name = Contact.Name,
            Url = Contact.Url,
            Email = Contact.Email
        };

    [JsonIgnore]
    public NSwag.OpenApiLicense SwaggerLicense =>
        _license ??= new() { Name = License.Name, Url = License.Url };

    public string Title { get; set; } = "GF.Web";

    public string Version { get; set; } = "0.0.1";

#pragma warning disable IDE1006
    public SwaggerContact Contact { get; set; } = new SwaggerContact();

    public SwaggerLicense License { get; set; } = new SwaggerLicense();
#pragma warning restore
}

public class SwaggerContact : IOption
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

public class SwaggerLicense : IOption
{
    public string Name { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
