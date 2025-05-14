using server;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer()
    .WithTools<Tools>();


builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();

app.Run();