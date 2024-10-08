﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("API.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BekanntAls")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ErstelltAm")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Geburtsdatum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Geschlecht")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Interessen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswortHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswortSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Stadt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SuchtNach")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vorstellung")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ZuletztAktiv")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("API.Models.Foto", b =>
                {
                    b.HasOne("API.Models.AppUser", "AppUser")
                        .WithMany("Fotos")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Models.AppUser", b =>
                {
                    b.Navigation("Fotos");
                });
#pragma warning restore 612, 618
        }
    }
}
