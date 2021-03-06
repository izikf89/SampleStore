// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(WebApplication2Context))]
    [Migration("20210531205451_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryProdact", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProdactsProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesCategoryId", "ProdactsProductId");

                    b.HasIndex("ProdactsProductId");

                    b.ToTable("CategoryProdact");
                });

            modelBuilder.Entity("WebApplication2.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("WebApplication2.Models.CategoryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("CategoryImage");
                });

            modelBuilder.Entity("WebApplication2.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApplication2.Models.Prodact", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("Prodact");
                });

            modelBuilder.Entity("WebApplication2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("WebApplication2.Models.productImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdactProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdactProductId");

                    b.ToTable("productImage");
                });

            modelBuilder.Entity("WebApplication2.Models.Client", b =>
                {
                    b.HasBaseType("WebApplication2.Models.User");

                    b.Property<string>("E_Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("CategoryProdact", b =>
                {
                    b.HasOne("WebApplication2.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.Prodact", null)
                        .WithMany()
                        .HasForeignKey("ProdactsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication2.Models.CategoryImage", b =>
                {
                    b.HasOne("WebApplication2.Models.Category", "Category")
                        .WithOne("Image")
                        .HasForeignKey("WebApplication2.Models.CategoryImage", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApplication2.Models.Order", b =>
                {
                    b.HasOne("WebApplication2.Models.Client", null)
                        .WithMany("Orders")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("WebApplication2.Models.Prodact", b =>
                {
                    b.HasOne("WebApplication2.Models.Order", null)
                        .WithMany("Prodacts")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("WebApplication2.Models.productImage", b =>
                {
                    b.HasOne("WebApplication2.Models.Prodact", null)
                        .WithMany("Pictuers")
                        .HasForeignKey("ProdactProductId");
                });

            modelBuilder.Entity("WebApplication2.Models.Category", b =>
                {
                    b.Navigation("Image");
                });

            modelBuilder.Entity("WebApplication2.Models.Order", b =>
                {
                    b.Navigation("Prodacts");
                });

            modelBuilder.Entity("WebApplication2.Models.Prodact", b =>
                {
                    b.Navigation("Pictuers");
                });

            modelBuilder.Entity("WebApplication2.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
