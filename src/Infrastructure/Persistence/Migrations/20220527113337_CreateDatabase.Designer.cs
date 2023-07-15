﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(CAContext))]
    [Migration("20220527113337_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43db034a-98cc-42ee-8fff-c57016484f4d"),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailConfirmationCode")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("EmailConfirmedCode")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("ResetPasswordCode")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                            Email = "defaultadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Default",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 30, 26, 213, 8, 103, 48, 182, 118, 120, 144, 112, 216, 242, 40, 40, 207, 239, 96, 119, 49, 33, 171, 55, 121, 126, 118, 156, 120, 77, 215, 156, 72, 179, 105, 183, 56, 0, 241, 155, 101, 195, 120, 71, 19, 202, 24, 89, 175, 55, 34, 225, 108, 10, 165, 18, 204, 237, 134, 207, 84, 99, 154, 47, 187 },
                            PasswordSalt = new byte[] { 249, 241, 17, 68, 23, 112, 83, 99, 27, 23, 64, 13, 227, 155, 63, 133, 99, 58, 201, 76, 70, 85, 152, 9, 70, 66, 108, 245, 248, 18, 81, 251, 62, 224, 104, 49, 200, 148, 2, 170, 114, 145, 100, 43, 6, 123, 10, 84, 187, 121, 24, 246, 140, 224, 220, 192, 149, 138, 206, 19, 121, 210, 255, 199, 215, 59, 144, 106, 249, 124, 89, 200, 250, 38, 182, 73, 82, 22, 204, 110, 185, 148, 190, 61, 240, 51, 253, 98, 3, 178, 132, 83, 200, 211, 185, 10, 10, 240, 232, 227, 222, 171, 218, 46, 2, 185, 11, 241, 191, 195, 67, 159, 124, 120, 65, 168, 254, 123, 30, 84, 153, 105, 64, 114, 183, 158, 125, 252 },
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6e5d8fa8-fa96-419f-9c07-3e05b96b087e"),
                            RoleId = new Guid("43db034a-98cc-42ee-8fff-c57016484f4d")
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
