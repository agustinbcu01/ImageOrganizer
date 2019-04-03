using Business.DB.Dbo;
using Business.Services;
using Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DB
{
    public class ImageOrganizerContex : BaseDbContext
    {
        public DbSet<Configuration> Configurations { get; set; }
       // public DbSet<FolderEntry> FolderEntries { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Archive> Pending { get; set; }
       /* public ImageOrganizerContex(DbContextOptions<DbContext> options) : base(options, new UserService(), new TimeService())
        {

        }*/
        public ImageOrganizerContex(DbContextOptions<ImageOrganizerContex> options, IUserService userService, ITimeService timeService) : base(options, userService, timeService)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Configuration>().HasData(
                new Configuration(){ Id = EConfigurationKey.rootPath, Name= "Root Path", Value = @"E:\MediaRoot" },
                new Configuration() { Id = EConfigurationKey.timeOut, Name = "Time Out", Value ="10" },
                new Configuration() { Id = EConfigurationKey.dropLocation, Name = "Drop Location", Value = @"E:\Drop" }
                );

            modelBuilder.Entity<Archive>().HasIndex((entry) => entry.Path);
            modelBuilder.Entity<Folder>().HasIndex((entry) => entry.Path);
            modelBuilder.Entity<Folder>().HasIndex((entry) => entry.Crc);
            modelBuilder.Entity<Archive>().HasIndex((entry) => entry.Crc);

         

        }

    }
}
