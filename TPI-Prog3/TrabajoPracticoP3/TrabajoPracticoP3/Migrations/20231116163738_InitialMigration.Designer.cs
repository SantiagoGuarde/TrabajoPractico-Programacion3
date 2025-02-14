﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabajoPracticoP3.DBContext;

#nullable disable

namespace TrabajoPracticoP3.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231116163738_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Payment")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TotalPrize")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pizza de Muzzarella",
                            Price = "3000",
                            State = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pizza de Jamon",
                            Price = "3500",
                            State = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pizza de Pepperoni",
                            Price = "4000",
                            State = true
                        });
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.SaleOrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductQuntity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderId1");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleOrderLines");
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SurName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("TrabajoPracticoP3.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "JuanPerez@gmail.com",
                            Name = "Juan",
                            Password = "987654",
                            State = true,
                            SurName = "Perez",
                            UserName = "JuancitoPerez",
                            UserType = "Admin"
                        });
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.Client", b =>
                {
                    b.HasBaseType("TrabajoPracticoP3.Data.Entities.User");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "Erne22@gmail.com",
                            Name = "Ernesto",
                            Password = "123321",
                            State = true,
                            SurName = "Gutierrez",
                            UserName = "ElGuason21",
                            UserType = "Client",
                            PhoneNumber = "3415123212"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Seba25@gmail.com",
                            Name = "Sebastuan",
                            Password = "554466",
                            State = true,
                            SurName = "Gonzalez",
                            UserName = "Batman21",
                            UserType = "Client",
                            PhoneNumber = "3415123333"
                        });
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.Order", b =>
                {
                    b.HasOne("TrabajoPracticoP3.Data.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.SaleOrderLine", b =>
                {
                    b.HasOne("TrabajoPracticoP3.Data.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoPracticoP3.Data.Entities.Order", null)
                        .WithMany("SaleOrderLine")
                        .HasForeignKey("OrderId1");

                    b.HasOne("TrabajoPracticoP3.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TrabajoPracticoP3.Data.Entities.Order", b =>
                {
                    b.Navigation("SaleOrderLine");
                });
#pragma warning restore 612, 618
        }
    }
}
