﻿// <auto-generated />
using System;
using DesafioBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DesafioBackend.Migrations
{
    [DbContext(typeof(EFDbContext))]
    partial class EFDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DesafioBackend.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("358b0e4d-3de5-4f72-9b54-1ce3e96cd749"),
                            Created = new DateTime(2022, 2, 13, 19, 19, 47, 559, DateTimeKind.Local).AddTicks(4454),
                            Modified = new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7332),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("da27ffa7-c483-4e6d-b6f9-3ce15edf9ac1"),
                            Created = new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7850),
                            Modified = new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7857),
                            Name = "Caixa"
                        },
                        new
                        {
                            Id = new Guid("cc9d6a68-8d33-45f8-844d-9e1209af0041"),
                            Created = new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7860),
                            Modified = new DateTime(2022, 2, 13, 19, 19, 47, 560, DateTimeKind.Local).AddTicks(7861),
                            Name = "Operador"
                        });
                });

            modelBuilder.Entity("DesafioBackend.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProfileUser", b =>
                {
                    b.Property<Guid>("ProfilesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("ProfilesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ProfileUser");
                });

            modelBuilder.Entity("ProfileUser", b =>
                {
                    b.HasOne("DesafioBackend.Entities.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioBackend.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
