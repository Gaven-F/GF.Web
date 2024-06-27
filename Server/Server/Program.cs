var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(c => { });
builder.Services.AddOpenApiDocument(
    (c) =>
    {
        c.PostProcess = p =>
        {
            p.Info.Title = "GF.Web";
            p.Info.Version = "¦Á.0.1";
            p.Info.Contact = new NSwag.OpenApiContact()
            {
                Name = "GavenF",
                Email = "gavenf2023@outlook.com",
            };
            //p.Info.License = new NSwag.OpenApiLicense()
            //{
            //    Name = "MIT",
            //};
        };
        c.DocumentName = "Default";
        c.Title = "GF.Web";
        c.ApiGroupNames = ["Default"];
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
