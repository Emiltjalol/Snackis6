using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Snackis6.Areas.Identity.Data;
using Snackis6.Data;
namespace Snackis6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Snackis6ContextConnection") ?? throw new InvalidOperationException("Connection string 'Snackis6ContextConnection' not found.");

      
            builder.Services.AddDbContext<Snackis6Context>(options =>
               options.UseSqlServer(connectionString));




  

            builder.Services.AddDefaultIdentity<Areas.Identity.Data.Snackis6User>(options =>
            options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<Snackis6Context>();






            builder.Services.AddRazorPages();
            builder.Services.AddHttpClient();

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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
