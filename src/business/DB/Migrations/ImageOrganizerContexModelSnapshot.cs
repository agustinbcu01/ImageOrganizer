﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Business.DB;

namespace Business.DB.Migrations
{
    [DbContext(typeof(ImageOrganizerContex))]
    partial class ImageOrganizerContexModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Business.DB.Dbo.Archive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArchiveStatus");

                    b.Property<string>("Crc");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("EntryCreateAt");

                    b.Property<DateTime>("EntryModifiedAt");

                    b.Property<int?>("FolderId");

                    b.Property<int>("Mediatype");

                    b.Property<string>("MetaDada");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("Crc");

                    b.HasIndex("FolderId");

                    b.HasIndex("Path");

                    b.ToTable("Archive");
                });

            modelBuilder.Entity("Business.DB.Dbo.Configuration", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Configurations");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Name = "Root Path",
                            Value = "E:\\MediaRoot"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Time Out",
                            Value = "10"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drop Location",
                            Value = "E:\\Drop"
                        });
                });

            modelBuilder.Entity("Business.DB.Dbo.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Crc");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("EntryCreateAt");

                    b.Property<DateTime>("EntryModifiedAt");

                    b.Property<int?>("FolderId");

                    b.Property<int>("FolderType");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("Crc");

                    b.HasIndex("FolderId");

                    b.HasIndex("Path");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("Business.DB.Dbo.Archive", b =>
                {
                    b.HasOne("Business.DB.Dbo.Folder")
                        .WithMany("Archives")
                        .HasForeignKey("FolderId");
                });

            modelBuilder.Entity("Business.DB.Dbo.Folder", b =>
                {
                    b.HasOne("Business.DB.Dbo.Folder")
                        .WithMany("Folders")
                        .HasForeignKey("FolderId");
                });
#pragma warning restore 612, 618
        }
    }
}
