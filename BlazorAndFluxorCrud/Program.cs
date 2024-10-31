using BlazorAndFluxorCrud.Components;
using BlazorAndFluxorCrud.Effects;
using BlazorAndFluxorCrud.Model;
using BlazorAndFluxorCrud.Service;

using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;

using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(Program).Assembly);
    o.UseReduxDevTools(rdt =>
    {
        rdt.Name = "My application";
    });

});
builder.Services.AddScoped<ItemEffects>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=items.db"));
builder.Services.AddScoped<DialogUIService>();
builder.Services.AddMudServices();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
