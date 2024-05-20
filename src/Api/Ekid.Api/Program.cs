using Ekid.Api;
using Ekid.Identity.Api;
using Ekid.Infrastructure.ModuleContext;
using Ekid.Infrastructure.Security;
using Ekid.Resources.Api;

var builder = WebApplication.CreateBuilder(args);

Modules.RegisterModule<IdentityModule>();
Modules.RegisterModule<ResourcesModule>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationComponents(builder.Configuration);

var app = builder.Build();

//TODO ensure db created

app.Services.RegisterAllPermissions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting()
    .UseEndpoints(endpoints =>
{
    endpoints.UseModuleEndpoints();
});

app.Run();