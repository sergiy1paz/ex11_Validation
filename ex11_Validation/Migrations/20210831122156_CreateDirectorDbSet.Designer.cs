﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ex11_Validation.Database;

namespace ex11_Validation.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210831122156_CreateDirectorDbSet")]
    partial class CreateDirectorDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ex11_Validation.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ex11_Validation.Models.Director", b =>
                {
                    b.HasBaseType("ex11_Validation.Models.Person");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("ex11_Validation.Models.Employee", b =>
                {
                    b.HasBaseType("ex11_Validation.Models.Person");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ex11_Validation.Models.Manager", b =>
                {
                    b.HasBaseType("ex11_Validation.Models.Person");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("ex11_Validation.Models.Director", b =>
                {
                    b.HasOne("ex11_Validation.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("ex11_Validation.Models.Director", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ex11_Validation.Models.Employee", b =>
                {
                    b.HasOne("ex11_Validation.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("ex11_Validation.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ex11_Validation.Models.Manager", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("ex11_Validation.Models.Manager", b =>
                {
                    b.HasOne("ex11_Validation.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("ex11_Validation.Models.Manager", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ex11_Validation.Models.Manager", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
