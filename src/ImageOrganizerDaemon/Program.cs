using System;
using System.Threading.Tasks;
using Business.DB;
using Business.Services;
using Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ImageOrganizerDaemon
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddEnvironmentVariables();

                     if (args != null)
                     {
                         config.AddCommandLine(args);
                     }
                 })
                 .ConfigureServices((hostContext, services) =>
                 {
                     services.AddOptions();
                     services.Configure<DaemonConfig>(hostContext.Configuration.GetSection("Daemon"));

                     services.AddSingleton<IHostedService, DaemonService>();
                     services.AddScoped<IGenerationService, GenerationService>();
                     services.AddScoped<IDiscoverService, DiscoverServices>();
                     services.AddScoped<IFolderDiscoverService, FolderDiscoverService>();
                     services.AddScoped<IFileDiscoverService, FileDiscoverService>();
                     services.AddScoped<ICriptographicService, CriptographicService>();
                     services.AddScoped<ISyncService, SyncService>();
                     services.AddScoped<IConfigurtationService, ConfigurtationService>();

                     services.AddSingleton<ITimeService, TimeService>();
                     services.AddSingleton<IUserService, UserService>();

                     var migrationassembly = typeof(ImageOrganizerContex).Assembly.FullName;

                     services.AddDbContext<ImageOrganizerContex>( 
                        options => options.UseMySql("server=localhost;database=image_organizer;uid=root;pwd=decatb09;", // replace with your Connection String
                            mysqlOptions =>
                            {
                                mysqlOptions.ServerVersion(new Version(8, 0, 11), ServerType.MySql); // replace with your Server Version and Type
                                mysqlOptions.MigrationsAssembly(migrationassembly);
                            }
                    ));


                 })
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     logging.AddConsole();
                 });

            await builder.RunConsoleAsync();
        }
    }
}
