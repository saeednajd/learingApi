﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapitwo;

#nullable disable

namespace webapitwo.Migrations
{
    [DbContext(typeof(Libcontext))]
    partial class LibcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapitwo.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookandshelfid")
                        .HasColumnType("int");

                    b.Property<int>("Bookshelfandbookid")
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Userandbookid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("webapitwo.Model.Bookandshelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookid")
                        .HasColumnType("int");

                    b.Property<int>("Shelfid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Bookid");

                    b.HasIndex("Shelfid");

                    b.ToTable("Bookandshelf", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookshelfandbookid")
                        .HasColumnType("int");

                    b.Property<int>("Bookshelfandshelfid")
                        .HasColumnType("int");

                    b.Property<int>("Bookshelfanduserid")
                        .HasColumnType("int");

                    b.Property<int>("Bookstatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bookshelf", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelfandbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookid")
                        .HasColumnType("int");

                    b.Property<int>("Bookshelfid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Bookid");

                    b.HasIndex("Bookshelfid");

                    b.ToTable("Bookshelfandbook", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelfandshelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookshelfid")
                        .HasColumnType("int");

                    b.Property<int>("Shelfid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Bookshelfid");

                    b.HasIndex("Shelfid");

                    b.ToTable("Bookshelfandshelf", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelfanduser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookshelfid")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Bookshelfid");

                    b.HasIndex("Userid");

                    b.ToTable("Bookshelfanduser", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookandshelfid")
                        .HasColumnType("int");

                    b.Property<int>("Bookshelfandshelfid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.ToTable("Shelf", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookshelfanduserid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Joindate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shelfid")
                        .HasColumnType("int");

                    b.Property<int>("Userandbookid")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.Userandbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bookid")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Bookid");

                    b.HasIndex("Userid");

                    b.ToTable("Userandbook", (string)null);
                });

            modelBuilder.Entity("webapitwo.Model.Bookandshelf", b =>
                {
                    b.HasOne("webapitwo.Model.Book", "Book")
                        .WithMany("Bookandshelves")
                        .HasForeignKey("Bookid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapitwo.Model.Shelf", "Shelf")
                        .WithMany("Bookandshelfs")
                        .HasForeignKey("Shelfid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelfandbook", b =>
                {
                    b.HasOne("webapitwo.Model.Book", "Book")
                        .WithMany("Bookshelfandbooks")
                        .HasForeignKey("Bookid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapitwo.Model.Bookshelf", "Bookshelf")
                        .WithMany("Bookshelfandbooks")
                        .HasForeignKey("Bookshelfid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Bookshelf");
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelfandshelf", b =>
                {
                    b.HasOne("webapitwo.Model.Bookshelf", "Bookshelf")
                        .WithMany("Bookshelfandshelves")
                        .HasForeignKey("Bookshelfid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapitwo.Model.Shelf", "Shelf")
                        .WithMany("Bookshelfandshelfs")
                        .HasForeignKey("Shelfid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bookshelf");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelfanduser", b =>
                {
                    b.HasOne("webapitwo.Model.Bookshelf", "Bookshelf")
                        .WithMany("Bookshelfandusers")
                        .HasForeignKey("Bookshelfid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapitwo.Model.User", "User")
                        .WithMany("Bookshelfandusers")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bookshelf");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapitwo.Model.Shelf", b =>
                {
                    b.HasOne("webapitwo.Model.User", "Oneuser")
                        .WithMany("Shelves")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oneuser");
                });

            modelBuilder.Entity("webapitwo.Model.Userandbook", b =>
                {
                    b.HasOne("webapitwo.Model.Book", "Book")
                        .WithMany("userandbooks")
                        .HasForeignKey("Bookid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapitwo.Model.User", "User")
                        .WithMany("userandbooks")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapitwo.Model.Book", b =>
                {
                    b.Navigation("Bookandshelves");

                    b.Navigation("Bookshelfandbooks");

                    b.Navigation("userandbooks");
                });

            modelBuilder.Entity("webapitwo.Model.Bookshelf", b =>
                {
                    b.Navigation("Bookshelfandbooks");

                    b.Navigation("Bookshelfandshelves");

                    b.Navigation("Bookshelfandusers");
                });

            modelBuilder.Entity("webapitwo.Model.Shelf", b =>
                {
                    b.Navigation("Bookandshelfs");

                    b.Navigation("Bookshelfandshelfs");
                });

            modelBuilder.Entity("webapitwo.Model.User", b =>
                {
                    b.Navigation("Bookshelfandusers");

                    b.Navigation("Shelves");

                    b.Navigation("userandbooks");
                });
#pragma warning restore 612, 618
        }
    }
}
