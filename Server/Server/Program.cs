using Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.EnableController().EnableSwaggerDoc();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.USwagger();

app.Run();
