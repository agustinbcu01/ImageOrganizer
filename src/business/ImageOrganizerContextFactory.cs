using Business.DB;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ImageOrganizerContextFactory : IDesignTimeDbContextFactory<ImageOrganizerContex>
    {
        public ImageOrganizerContex CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ImageOrganizerContex>();
            optionsBuilder.UseMySql("server=localhost;database=image_organizer;uid=root;pwd=decatb09;");

            return new ImageOrganizerContex(optionsBuilder.Options, new UserService(), new TimeService());
        }
    }
}
