using Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.EnableController().EnableSwaggerDoc();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.USwagger();
}

app.Run();
