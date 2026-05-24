using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Unihockey.Saisonmanager.Api;

var builder = WebApplication.CreateBuilder(args);

// Register HttpClient so it can be injected into the proxy endpoints
builder.Services.AddHttpClient();

var app = builder.Build();

// Retrieve the base URL for the external API from appsettings.json, 
// or fall back to a default value if it's not configured.
// Example appsettings.json entry:
// { "Saisonmanager": { "BaseUrl": "https://api.saisonmanager.de/v2/" } }
var externalApiBaseUrl = app.Configuration["Saisonmanager:BaseUrl"] 
                         ?? "https://api.saisonmanager.de/api/v2/";

// Map all the proxy endpoints using the stateless, zero-reflection engine
app.MapAllSmProxyEndpoints(externalApiBaseUrl);

app.Run();