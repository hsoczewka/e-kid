using Ekid.Infrastructure.Security;
using Ekid.Resources.Activities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddActivitiesComponents();

var app = builder.Build();

app.Services.RegisterAllPermissions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.MapControllers();
app.UseRouting()
    .UseEndpoints(endpoints =>
{
    endpoints.UseActivitiesEndpoints();

});

app.Run();