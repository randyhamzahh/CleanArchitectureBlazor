using Application.Interfaces;
using Application.UseCases;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Web.Components;

var builder = WebApplication.CreateBuilder(args);

// --- START: Dependency Injection Configuration ---

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add all our use cases
builder.Services.AddScoped<GetProductByIdQuery>();
builder.Services.AddScoped<GetAllProductsQuery>();
builder.Services.AddScoped<CreateProductCommand>();
builder.Services.AddScoped<UpdateProductCommand>();
builder.Services.AddScoped<DeleteProductCommand>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().BaseUri)
});

// --- END: Dependency Injection Configuration ---

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();