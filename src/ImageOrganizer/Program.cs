
using ImageOrganizer.Infrastructure;
using ImageOrganizer.Properties;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOrganizer
{
    static class Program
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            var opener = container.GetInstance<IFormOpener>();
            using (var form = opener.GetForm<FrmMain>())
            {
                Application.Run(form);
            }
        }

        private static void Bootstrap()
        {
            container = new Container();
          //  container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

          /*  container.Register<DbContext>(() =>
            {
                DbContextOptionsBuilder<ImagenOrganizerContex> optionsBuilder = new DbContextOptionsBuilder<ImagenOrganizerContex>();
                optionsBuilder.UseMySql(Settings.Default.cnxStringMySql, // replace with your Connection String
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(8,0,11), ServerType.MySql); // replace with your Server Version and Type
                    }
            );  
                return new ImagenOrganizerContex(optionsBuilder.Options);
            }, Lifestyle.Singleton);*/

          /*  container.AddDbContextPool<ImagenOrganizerContex>( // replace "YourDbContext" with the class name of your DbContext
                options => options.UseMySql(Settings.Default.cnxStringMySql, // replace with your Connection String
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                    }
            ));*/

          //  container.Register<IConfigurationS, ConfigurationS34>();
            container.RegisterSingleton<IFormOpener, FormOpener>();
           // container.Register<FrmMain>();

            // Optionally verify the container.
            container.Verify();
        }
    }
}
