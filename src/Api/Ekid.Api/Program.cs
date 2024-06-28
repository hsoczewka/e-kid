using Ekid.Api;
using Ekid.Identity.Api;
using Ekid.Infrastructure.ModuleContext;
using Ekid.Resources.Api;

var builder = WebApplication.CreateBuilder(args);

Modules.RegisterModule<IdentityModule>();
Modules.RegisterModule<ResourcesModule>();

builder.Services.AddApplicationComponents(builder.Configuration);

var app = builder.Build();
app.UseApplicationComponents();
app.Run();