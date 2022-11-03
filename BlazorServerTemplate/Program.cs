using BlazorServerTemplate.Data;
using BlazorServerTemplate.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Radzen;


namespace BlazorServerTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            //Radzen
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            //local databases
            builder.Services.AddScoped<GlobalsService>();
            builder.Services.AddScoped<AppsDbService>();
            builder.Services.AddScoped<MasterDataDbService>();

            builder.Services.AddDbContext<MasterDataDbContextOld>(options => {
                options.UseSqlServer("Data Source=MasterDataTSTDB;Initial Catalog=TSMDD;Trusted_Connection=True;");});

            builder.Services.AddDbContext<FoundationTSContext>(options => {
                options.UseSqlServer("Data Source=MasterDataTSTDB;Initial Catalog=FoundationTS;Trusted_Connection=True;");});

            builder.Services.AddDbContext<AppsDbContext>(options => {
                options.UseSqlServer("Data Source=AppsTSTDB;Initial Catalog=Bucket;Trusted_Connection=True;");});


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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}