using Tweetbook.Installers;
using Tweetbook.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.InstallServicesInAssebly(builder.Configuration);

var app = builder.Build();

var swaggerOptions = new SwaggerOptions();
app.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(x => x.RouteTemplate = swaggerOptions.JsonRoute);
    app.UseSwaggerUI(x => x.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
