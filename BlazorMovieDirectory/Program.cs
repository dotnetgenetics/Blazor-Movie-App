using BlazorMovieDirectory.Components;
using BlazorMovieDirectory.Data;
using BlazorMovieDirectory.Infrastructure.Contracts;
using BlazorMovieDirectory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovieDirectory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                   .AddInteractiveServerComponents()
                   .AddInteractiveWebAssemblyComponents();

            builder.Services.AddDbContextFactory<MvcMovieContext>(options =>
            options.UseSqlServer(
                builder.Configuration["ConnectionStrings:MvcMovieContext"]
                ));

            builder.Services.AddScoped<IMovieRepository, MovieRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode();

            app.Run();
        }
    }
}
