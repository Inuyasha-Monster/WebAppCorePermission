using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EntityFrameworkCore;

namespace EntityFrameworkCore.Migrations
{
    [DbContext(typeof(PermissionDbContext))]
    [Migration("20170128084322_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:.uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("ContactNumber");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("CreateUserId");

                    b.Property<int>("IsDeleted");

                    b.Property<string>("Manager");

                    b.Property<string>("Name");

                    b.Property<Guid>("ParentId");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Icon");

                    b.Property<string>("Name");

                    b.Property<Guid>("ParentId");

                    b.Property<string>("Remarks");

                    b.Property<int>("SerialNumber");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("CreateUserId");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.RoleMenu", b =>
                {
                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("MenuId");

                    b.HasKey("RoleId", "MenuId");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleMenus");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateTime");

                    b.Property<Guid>("CreateUserId");

                    b.Property<Guid>("DepartmentId");

                    b.Property<string>("EMail");

                    b.Property<int>("IsDeleted");

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<int>("LoginTimes");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Remarks");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.RoleMenu", b =>
                {
                    b.HasOne("Domain.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
