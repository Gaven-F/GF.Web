using NSwag.Generation.AspNetCore;
using Server.Commons;

var builder = WebApplication.CreateBuilder(args);

var swagger = new SwaggerOptions();

builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swagger);
builder.Services.AddControllers(c => { });
builder.Services.AddOpenApiDocument(
    (c) =>
    {
        c.PostProcess = p =>
        {
            p.Info.Title = swagger.Doc.PostProcess.Title;
            p.Info.Version = swagger.Doc.PostProcess.Version;
            p.Info.Contact = swagger.Doc.PostProcess.SwaggerContact;
            p.Info.License = swagger.Doc.PostProcess.SwaggerLicense;
        };
        c.DocumentName = swagger.Doc.Name;
        c.Title = swagger.Doc.Title;
        c.Description = swagger.Doc.Description;
        c.ApiGroupNames = swagger.Doc.GroupNames;
    }
);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseOpenApi(c => { });
app.UseSwaggerUi(c =>
{
    c.Path = string.Empty;
});
app.MapControllers();

app.Run();
