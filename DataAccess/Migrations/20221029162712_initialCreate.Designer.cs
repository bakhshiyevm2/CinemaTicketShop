// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221029162712_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entites.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("DataAccess.Entites.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("integer");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(4767),
                            CreateUserId = 1,
                            ImgPath = "~/img/pulp_fict.jpg",
                            Name = "Movie",
                            Note = "Description",
                            Price = 5.0
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(4794),
                            CreateUserId = 1,
                            ImgPath = "~/img/pulp_fict.jpg",
                            Name = "Test",
                            Note = "Description",
                            Price = 15.0
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(4807),
                            CreateUserId = 1,
                            ImgPath = "~/img/pulp_fict.jpg",
                            Name = "123123",
                            Note = "Description",
                            Price = 55.0
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(4821),
                            CreateUserId = 1,
                            ImgPath = "~/img/pulp_fict.jpg",
                            Name = "Testmurad",
                            Note = "Description",
                            Price = 25.0
                        },
                        new
                        {
                            Id = 5,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(4834),
                            CreateUserId = 1,
                            ImgPath = "~/img/pulp_fict.jpg",
                            Name = "MuradMovie",
                            Note = "Description",
                            Price = 51.0
                        },
                        new
                        {
                            Id = 6,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(4855),
                            CreateUserId = 1,
                            ImgPath = "~/img/pulp_fict.jpg",
                            Name = "Test 2",
                            Note = "Description",
                            Price = 6.0
                        });
                });

            modelBuilder.Entity("DataAccess.Entites.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(3079),
                            CreateUserId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(3163),
                            CreateUserId = 1,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("DataAccess.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UpdateUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2022, 10, 29, 20, 27, 12, 693, DateTimeKind.Local).AddTicks(4704),
                            CreateUserId = 1,
                            PasswordHash = ">M>Aɳ֛2���^#��s�cH]�ݠ�i�",
                            RoleId = 1,
                            Salt = "8QykOR/Z+vHGkA==",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DataAccess.Entites.Cart", b =>
                {
                    b.HasOne("DataAccess.Entites.Product", "Product")
                        .WithMany("Cart")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Entites.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Entites.User", b =>
                {
                    b.HasOne("DataAccess.Entites.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DataAccess.Entites.Product", b =>
                {
                    b.Navigation("Cart");
                });

            modelBuilder.Entity("DataAccess.Entites.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DataAccess.Entites.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
