using NSwag.Generation.AspNetCore;
using Server.Commons;

var builder = WebApplication.CreateBuilder(args);

var swaggerOptions = new SwaggerOptions();
builder.Configuration.Bind(swaggerOptions);
var o = new AspNetCoreOpenApiDocumentGeneratorSettings();
builder.Services.AddControllers(c => { });
builder.Services.AddOpenApiDocument(
    (c) =>
    {
        c.PostProcess = p =>
        {
            p.Info.Title = swaggerOptions.Doc.PostProcess.Title;
            p.Info.Version = swaggerOptions.Doc.PostProcess.Version;
            p.Info.Contact = swaggerOptions.Doc.PostProcess.Contact;
            p.Info.License = swaggerOptions.Doc.PostProcess.License;
        };
        c.DocumentName = swaggerOptions.Doc.Name;
        c.Title = swaggerOptions.Doc.Title;
        c.Description = swaggerOptions.Doc.Description;
        c.ApiGroupNames = swaggerOptions.Doc.GroupNames;
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
