﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Property<int>("idCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCategory"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idCategory");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("WebApplication1.Models.Country_Manufacturer", b =>
                {
                    b.Property<int>("idCountryManufacturer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCountryManufacturer"));

                    b.Property<string>("countryManufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idCountryManufacturer");

                    b.ToTable("country_Manufacturers");
                });

            modelBuilder.Entity("WebApplication1.Models.Firm", b =>
                {
                    b.Property<int>("idFirm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idFirm"));

                    b.Property<string>("firm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idFirm");

                    b.ToTable("firms");
                });

            modelBuilder.Entity("WebApplication1.Models.Material", b =>
                {
                    b.Property<int>("idMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMaterial"));

                    b.Property<string>("material")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idMaterial");

                    b.ToTable("materials");
                });

            modelBuilder.Entity("WebApplication1.Models.Product", b =>
                {
                    b.Property<int>("idProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProduct"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("idCategory")
                        .HasColumnType("int");

                    b.Property<int>("idCountryManufacturer")
                        .HasColumnType("int");

                    b.Property<int>("idFirm")
                        .HasColumnType("int");

                    b.Property<int>("idMaterial")
                        .HasColumnType("int");

                    b.Property<int>("idSupplier")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idProduct");

                    b.HasIndex("idCategory");

                    b.HasIndex("idCountryManufacturer");

                    b.HasIndex("idFirm");

                    b.HasIndex("idMaterial");

                    b.HasIndex("idSupplier");

                    b.ToTable("products");
                });

            modelBuilder.Entity("WebApplication1.Models.Role", b =>
                {
                    b.Property<int>("idRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idRole"));

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idRole");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("WebApplication1.Models.Supplier", b =>
                {
                    b.Property<int>("idSupplier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idSupplier"));

                    b.Property<string>("supplier")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idSupplier");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUser"));

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("firstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("idRole")
                        .HasColumnType("int");

                    b.Property<string>("lastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("middleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("idUser");

                    b.HasIndex("idRole");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebApplication1.Models.Product", b =>
                {
                    b.HasOne("WebApplication1.Models.Category", "Category")
                        .WithMany("products")
                        .HasForeignKey("idCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Country_Manufacturer", "Country_Manufacturer")
                        .WithMany("products")
                        .HasForeignKey("idCountryManufacturer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Firm", "Firm")
                        .WithMany("products")
                        .HasForeignKey("idFirm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Material", "Material")
                        .WithMany("products")
                        .HasForeignKey("idMaterial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Supplier", "Supplier")
                        .WithMany("products")
                        .HasForeignKey("idSupplier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Country_Manufacturer");

                    b.Navigation("Firm");

                    b.Navigation("Material");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.HasOne("WebApplication1.Models.Role", "Role")
                        .WithMany("users")
                        .HasForeignKey("idRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplication1.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("WebApplication1.Models.Country_Manufacturer", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("WebApplication1.Models.Firm", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("WebApplication1.Models.Material", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("WebApplication1.Models.Role", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("WebApplication1.Models.Supplier", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
